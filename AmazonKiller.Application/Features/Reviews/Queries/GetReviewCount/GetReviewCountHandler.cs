using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewCount;

public class GetReviewCountHandler : IRequestHandler<GetReviewCountQuery, int>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewCountHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<int> Handle(GetReviewCountQuery request, CancellationToken cancellationToken)
    {
        return await _reviewRepository.GetReviewCountAsync(request.ProductId);
    }
}