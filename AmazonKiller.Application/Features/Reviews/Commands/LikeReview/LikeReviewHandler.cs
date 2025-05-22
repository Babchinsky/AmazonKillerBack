using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.LikeReview;

public class LikeReviewHandler(
    IReviewRepository repo,
    ICurrentUserService currentUser)
    : IRequestHandler<LikeReviewCommand, Unit>
{
    public async Task<Unit> Handle(LikeReviewCommand cmd, CancellationToken ct)
    {
        await repo.ToggleLikeAsync(cmd.ReviewId, currentUser.UserId, ct);
        return Unit.Value;
    }
}