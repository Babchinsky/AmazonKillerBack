using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewHandler(
    IReviewRepository reviewRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    IFileStorage fileStorage
) : IRequestHandler<UpdateReviewCommand, Guid>
{
    public async Task<Guid> Handle(UpdateReviewCommand r, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var oldReview = await reviewRepo.Queryable()
                            .Where(x => x.Id == r.Id)
                            .Select(x => new { x.Id, x.UserId, x.ProductId, x.ImageUrls, x.RowVersion })
                            .FirstOrDefaultAsync(ct)
                        ?? throw new NotFoundException("Review not found");

        if (oldReview.UserId != currentUserId)
            throw new AppException("Forbidden", 403);

        var uploadedPaths = new List<string>();
        foreach (var file in r.UploadedFiles)
        {
            await using var stream = file.OpenReadStream();
            uploadedPaths.Add(await fileStorage.SaveAsync(stream, Path.GetExtension(file.FileName), ct));
        }

        var review = new Review
        {
            Id = r.Id,
            ProductId = oldReview.ProductId,
            UserId = oldReview.UserId,
            Rating = r.Rating,
            Article = r.Article,
            Message = r.Message,
            ImageUrls = uploadedPaths,
            Tags = r.Tags,
            RowVersion = Convert.FromBase64String(r.RowVersion)
        };

        try
        {
            await reviewRepo.UpdateAsync(review, ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            await fileStorage.DeleteBatchSafeAsync(uploadedPaths, ct);
            throw new AppException("The review was modified by another user. Please refresh and try again.", 409);
        }

        var imagesToDelete = oldReview.ImageUrls.Except(uploadedPaths, StringComparer.OrdinalIgnoreCase);
        await fileStorage.DeleteBatchSafeAsync(imagesToDelete.ToList(), ct);

        return review.Id;
    }
}