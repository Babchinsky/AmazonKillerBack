using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewHandler(
    IReviewRepository repo,
    IMapper mapper,
    ICurrentUserService currentUser,
    IFileStorage fileStorage
) : IRequestHandler<UpdateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(UpdateReviewCommand r, CancellationToken ct)
    {
        var oldReview = await repo.Queryable()
                            .Where(x => x.Id == r.Id)
                            .Select(x => new { x.Id, x.UserId, x.ProductId, x.ImageUrls, x.RowVersion })
                            .FirstOrDefaultAsync(ct)
                        ?? throw new NotFoundException("Review not found");

        if (oldReview.UserId != currentUser.UserId)
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
            await repo.UpdateAsync(review, ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            await fileStorage.DeleteBatchSafeAsync(uploadedPaths, ct);
            throw new AppException("The review was modified by another user. Please refresh and try again.", 409);
        }

        var imagesToDelete = oldReview.ImageUrls.Except(uploadedPaths, StringComparer.OrdinalIgnoreCase);
        await fileStorage.DeleteBatchSafeAsync(imagesToDelete.ToList(), ct);

        var entity = await repo.Queryable()
            .Include(x => x.Product)
            .Include(x => x.User)
            .Include(x => x.LikesFromUsers)
            .FirstAsync(x => x.Id == r.Id, ct);

        return mapper.Map<ReviewDto>(entity);
    }
}