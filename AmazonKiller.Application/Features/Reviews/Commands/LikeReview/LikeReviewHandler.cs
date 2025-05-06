using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.LikeReview;

public class LikeReviewHandler(IReviewRepository repo) : IRequestHandler<LikeReviewCommand, Unit>
{
    public async Task<Unit> Handle(LikeReviewCommand cmd, CancellationToken ct)
    {
        await repo.LikeAsync(cmd.ReviewId, ct);
        return Unit.Value;
    }
}