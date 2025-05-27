using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Account.Commands.LikeReview;

public class LikeReviewHandler(
    IReviewRepository reviewRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService)
    : IRequestHandler<LikeReviewCommand, Unit>
{
    public async Task<Unit> Handle(LikeReviewCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        await reviewRepo.ToggleLikeAsync(cmd.ReviewId, currentUserId, ct);
        return Unit.Value;
    }
}