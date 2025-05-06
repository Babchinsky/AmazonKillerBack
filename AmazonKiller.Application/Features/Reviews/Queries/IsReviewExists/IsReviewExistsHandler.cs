using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.IsReviewExists;

public class IsReviewExistsHandler(IReviewRepository repo) : IRequestHandler<IsReviewExistsQuery, bool>
{
    public async Task<bool> Handle(IsReviewExistsQuery request, CancellationToken cancellationToken)
    {
        return await repo.IsExistsAsync(request.Id);
    }
}