using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewById;

public class GetReviewByIdHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await repo.GetByIdAsync(request.Id);

        if (review == null)
            throw new NotFoundException($"Review with ID {request.Id} not found.");

        return mapper.Map<ReviewDto>(review);
    }
}