using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Commands.DeleteReview;

public class DeleteReviewHandler(IReviewRepository repo)
    : IRequestHandler<DeleteReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        if (!await repo.IsExistsAsync(request.Id))
            return false;

        await repo.DeleteAsync(request.Id);
        return true;
    }
}