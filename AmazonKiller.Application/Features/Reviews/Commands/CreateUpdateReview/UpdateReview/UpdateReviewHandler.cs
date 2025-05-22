using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.UpdateReview;

public class UpdateReviewHandler(
    IReviewRepository repo,
    IMapper mapper,
    ICurrentUserService currentUser,
    IFileStorage files
) : IRequestHandler<UpdateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(UpdateReviewCommand r, CancellationToken ct)
    {
        var oldReview = await repo.Queryable()
                            .Where(x => x.Id == r.Id)
                            .Select(x => new { x.Id, x.UserId, x.FilePaths, x.RowVersion })
                            .FirstOrDefaultAsync(ct)
                        ?? throw new NotFoundException("Review not found");

        if (oldReview.UserId != currentUser.UserId)
            throw new AppException("Forbidden", 403);

        var oldPaths = oldReview.FilePaths.ToList();

        var uploadedPaths = new List<string>();
        foreach (var file in r.UploadedFiles)
        {
            await using var stream = file.OpenReadStream();
            uploadedPaths.Add(await files.SaveAsync(stream, Path.GetExtension(file.FileName), ct));
        }

        var review = new Review
        {
            Id = r.Id,
            Rating = r.Rating,
            Article = r.Article,
            Message = r.Message,
            FilePaths = uploadedPaths,
            Tags = r.Tags,
            RowVersion = Convert.FromBase64String(r.RowVersion)
        };

        try
        {
            await repo.UpdateAsync(review, ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            await files.DeleteBatchSafeAsync(uploadedPaths, ct);
            throw new AppException("The review was modified by another user. Please refresh and try again.", 409);
        }

        var toDelete = oldPaths.Except(uploadedPaths, StringComparer.OrdinalIgnoreCase);
        await files.DeleteBatchSafeAsync(toDelete, ct);

        return await repo.Queryable()
            .Where(x => x.Id == r.Id)
            .ProjectTo<ReviewDto>(mapper.ConfigurationProvider)
            .FirstAsync(ct);
    }
}