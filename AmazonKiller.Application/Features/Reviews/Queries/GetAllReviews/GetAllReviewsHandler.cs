using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetAllReviewsQuery q, CancellationToken ct)
    {
        var query = repo.GetAllProjected()
            .AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters)
            .ApplyPagination(q.Parameters);

        var reviews = await query.ToListAsync(ct);
        return mapper.Map<List<ReviewDto>>(reviews);
    }
}