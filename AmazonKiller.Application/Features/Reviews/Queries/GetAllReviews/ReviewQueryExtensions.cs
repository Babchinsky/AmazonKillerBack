using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Reviews;

namespace AmazonKiller.Application.Features.Reviews.Queries.GetAllReviews;

public static class ReviewQueryExtensions
{
    public static IQueryable<Review> ApplyFilters(this IQueryable<Review> query, GetAllReviewsQuery q)
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

    public static IQueryable<Review> ApplySorting(this IQueryable<Review> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Review, object>>>
        {
            ["rating"] = r => r.Rating,
            ["createdat"] = r => r.CreatedAt,
            ["likes"] = r => r.LikesFromUsers.Count
        };

        return query.ApplySorting(parameters, sortMap);
    }
}