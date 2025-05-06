using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetReviewById;

public class GetReviewByIdHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(
        GetReviewByIdQuery q, CancellationToken ct) 
    {
        var r = await repo.GetByIdAsync(q.Id)
                ?? throw new NotFoundException("Review");
        return mapper.Map<ReviewDto>(r);
    }
}