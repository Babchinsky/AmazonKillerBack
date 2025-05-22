using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.UpdateReview;

public class UpdateReviewHandler(
    IReviewRepository repo,
    IMapper mapper,
    ICurrentUserService current,
    IFileStorage files)
    : IRequestHandler<UpdateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(UpdateReviewCommand r, CancellationToken ct)
    {
        var review = await repo.GetByIdAsync(r.Id) ?? throw new NotFoundException("Review");

        if (review.UserId != current.UserId)
            throw new AppException("Forbidden", 403);

        // сохраняем новые файлы
        var paths = new List<string>();
        foreach (var f in r.UploadedFiles)
        {
            await using var s = f.OpenReadStream();
            paths.Add(await files.SaveAsync(s, Path.GetExtension(f.FileName), ct));
        }

        review.Rating = r.Rating;
        review.Content.Article = r.Article;
        review.Content.Message = r.Message;
        review.Content.FilePaths = paths;

        await repo.UpdateAsync(review);
        return mapper.Map<ReviewDto>(review);
    }
}