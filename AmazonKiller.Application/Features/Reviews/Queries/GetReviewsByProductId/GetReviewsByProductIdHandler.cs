using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewsByProductId;

public class GetReviewsByProductIdHandler : IRequestHandler<GetReviewsByProductIdQuery, List<ReviewDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public GetReviewsByProductIdHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<List<ReviewDto>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetByProductIdAsync(request.ProductId);
        return _mapper.Map<List<ReviewDto>>(reviews);
    }
}