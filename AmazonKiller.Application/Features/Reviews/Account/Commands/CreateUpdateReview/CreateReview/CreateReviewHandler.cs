using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.CreateUpdateReview.CreateReview;

public class CreateReviewHandler(
    IReviewRepository reviewRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    IFileStorage fileStorage
) : IRequestHandler<CreateReviewCommand, Guid>
{
    public async Task<Guid> Handle(CreateReviewCommand r, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var imageUrls = new List<string>();
        foreach (var file in r.UploadedFiles)
        {
            await using var stream = file.OpenReadStream();
            imageUrls.Add(await fileStorage.SaveAsync(stream, Path.GetExtension(file.FileName), ct));
        }

        var review = new Review
        {
            Id = Guid.NewGuid(),
            ProductId = r.ProductId,
            UserId = currentUserId,
            Rating = r.Rating,
            Article = r.Article,
            Message = r.Message,
            ImageUrls = imageUrls,
            Tags = r.Tags,
            CreatedAt = DateTime.UtcNow
        };

        await reviewRepo.AddAsync(review, ct);
        return review.Id;
    }
}