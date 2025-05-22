using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Reviews;
using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;

public static class ReviewQueryExtensions
{
    public static IQueryable<ReviewDto> ApplyFilters(this IQueryable<ReviewDto> query, GetAllReviewsQuery q)
    {
        if (q.ProductId.HasValue)
            query = query.Where(r => r.ProductId == q.ProductId);

        if (q.UserId.HasValue)
            query = query.Where(r => r.UserId == q.UserId);

        if (q.MinRating.HasValue)
            query = query.Where(r => r.Rating >= q.MinRating);

        if (q.MaxRating.HasValue)
            query = query.Where(r => r.Rating <= q.MaxRating);

        return query;
    }

    public static IQueryable<ReviewDto> ApplySorting(this IQueryable<ReviewDto> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<ReviewDto, object>>>
        {
            ["rating"] = r => r.Rating,
            ["createdat"] = r => r.CreatedAt,
            ["likes"] = r => r.Likes
        };

        return query.ApplySorting(parameters, sortMap);
    }

    public static IQueryable<ReviewDto> ApplyPagination(this IQueryable<ReviewDto> query, QueryParameters parameters)
    {
        return query
            .Skip((parameters.Page - 1) * parameters.PageSize)
            .Take(parameters.PageSize);
    }
}