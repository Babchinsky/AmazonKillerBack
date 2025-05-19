using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Interfaces.Repositories.Reviews;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsHandler(IReviewRepository repo, IMapper mapper)
    : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetAllReviewsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking();

        if (q.ProductId.HasValue)
            query = query.Where(r => r.ProductId == q.ProductId);

        if (q.MinRating.HasValue)
            query = query.Where(r => (int)r.Rating >= q.MinRating);

        if (q.MaxRating.HasValue)
            query = query.Where(r => (int)r.Rating <= q.MaxRating);

        var sortMap = new Dictionary<string, Expression<Func<Domain.Entities.Reviews.Review, object>>>
        {
            ["rating"] = r => r.Rating,
            ["createdat"] = r => r.CreatedAt
        };

        query = query
            .ApplySorting(q.Parameters, sortMap)
            .ApplyPagination(q.Parameters);

        var list = await query.ToListAsync(ct);
        return mapper.Map<List<ReviewDto>>(list);
    }
}