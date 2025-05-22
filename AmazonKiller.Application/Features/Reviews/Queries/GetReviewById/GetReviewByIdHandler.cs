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
        var dto = await repo.GetDtoByIdAsync(q.Id, ct)
                  ?? throw new NotFoundException($"Review with id {q.Id} not found.");
        return dto;
    }
}