using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
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
        var review = await repo.GetByIdAsync(request.Id);
        if (review is null) return false;

        if (review.UserId != current.UserId)
            throw new AppException("Forbidden", 403);

        await repo.DeleteAsync(request.Id);
        return true;
    }
}