using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Reviews.Public.Queries.GetReviewById;

public class GetReviewByIdHandler(IReviewRepository repo)
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