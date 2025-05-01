using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAverageRating;

public class GetAverageRatingHandler(IReviewRepository repo) 
    : IRequestHandler<GetAverageRatingQuery, double>
{
    public async Task<double> Handle(GetAverageRatingQuery request, CancellationToken cancellationToken)
    {
        var averageRating = await repo.GetAverageRatingAsync(request.ProductId);
        return averageRating;
    }
}
