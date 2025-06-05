using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.DeleteOwnReview;

public class DeleteOwnReviewHandler(
    IReviewRepository reviewRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService)
    : IRequestHandler<DeleteOwnReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteOwnReviewCommand request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var review = await reviewRepo.GetEntityByIdAsync(request.Id, ct);
        if (review is null) return false;

        if (review.UserId != userId)
            throw new AppException("Forbidden", 403);

        await reviewRepo.DeleteAsync(review, ct);
        return true;
    }
}