using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewHandler(
    IReviewRepository repo,
    ICurrentUserService current)
    : IRequestHandler<DeleteReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken ct)
    {
        var review = await repo.GetEntityByIdAsync(request.Id, ct);
        if (review is null) return false;

        var isOwner = review.UserId == current.UserId;
        var isAdmin = current.Role == "Admin"; // или Enum, если ты используешь enum

        if (!isOwner && !isAdmin)
            throw new AppException("Forbidden", 403);

        await repo.DeleteAsync(review, ct);
        return true;
    }
}