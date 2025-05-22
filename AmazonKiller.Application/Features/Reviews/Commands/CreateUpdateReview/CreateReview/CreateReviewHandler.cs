using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewHandler(
    IReviewRepository repo,
    IMapper mapper,
    ICurrentUserService currentUser,
    IFileStorage files
) : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    public async Task<ReviewDto> Handle(CreateReviewCommand r, CancellationToken ct)
    {
        var filePaths = new List<string>();
        foreach (var file in r.UploadedFiles)
        {
            await using var stream = file.OpenReadStream();
            filePaths.Add(await files.SaveAsync(stream, Path.GetExtension(file.FileName), ct));
        }

        var review = new Review
        {
            Id = Guid.NewGuid(),
            ProductId = r.ProductId,
            UserId = currentUser.UserId,
            Rating = r.Rating,
            Article = r.Article,
            Message = r.Message,
            FilePaths = filePaths,
            Tags = r.Tags,
            CreatedAt = DateTime.UtcNow
        };

        await repo.AddAsync(review, ct);
        return mapper.Map<ReviewDto>(review);
    }
}