using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewsByProductId;

public class GetReviewsByProductIdHandler(IReviewRepository reviewRepository, IMapper mapper)
    : IRequestHandler<GetReviewsByProductIdQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
    {
        var reviews = await reviewRepository.GetByProductIdAsync(request.ProductId);
        return mapper.Map<List<ReviewDto>>(reviews);
    }
}