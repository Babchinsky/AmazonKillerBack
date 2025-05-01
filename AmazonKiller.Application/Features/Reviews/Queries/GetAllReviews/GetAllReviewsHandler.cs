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
        var query = repo.Queryable().AsQueryable();

        if (q.ProductId.HasValue)
            query = query.Where(r => r.ProductId == q.ProductId);

        if (q.MinRating.HasValue)
            query = query.Where(r => (int)r.Rating >= q.MinRating);

        if (q.MaxRating.HasValue)
            query = query.Where(r => (int)r.Rating <= q.MaxRating);

        if (!string.IsNullOrEmpty(q.SortBy))
            query = (q.SortBy.ToLower(), q.SortDesc) switch
            {
                ("rating", true) => query.OrderByDescending(r => r.Rating),
                ("rating", false) => query.OrderBy(r => r.Rating),
                ("createdat", true) => query.OrderByDescending(r => r.CreatedAt),
                ("createdat", false) => query.OrderBy(r => r.CreatedAt),
                _ => query
            };

        query = query
            .Skip((q.Page - 1) * q.PageSize)
            .Take(q.PageSize);

        var list = await EntityFrameworkQueryableExtensions.ToListAsync(query, ct);
        return mapper.Map<List<ReviewDto>>(list);
    }
}