using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Features.Products.Common;

public static class ProductQueryExtensions
{
    public static IQueryable<Product> ApplyFilters(
        this IQueryable<Product> query,
        IProductQueryWithFilters q,
        List<Guid>? categoryIds = null)
    {
        if (!string.IsNullOrWhiteSpace(q.SearchTerm))
        {
            var term = q.SearchTerm.Trim().ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(term) ||
                p.Code.ToLower().Contains(term) ||
                p.Id.ToString().ToLower().Contains(term));
        }

        if (categoryIds is not null && categoryIds.Count > 0)
            query = query.Where(p => categoryIds.Contains(p.CategoryId));
        else if (q.CategoryId.HasValue) query = query.Where(p => p.CategoryId == q.CategoryId.Value);

        if (q.MinPrice.HasValue)
            query = query.Where(p => p.Price >= q.MinPrice);

        if (q.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= q.MaxPrice);

        if (q.Rating.HasValue)
            query = query.Where(p => Math.Floor(p.Rating) == q.Rating.Value);

        if (q.Filters is null) return query;

        foreach (var (key, val) in q.Filters)
            query = query.Where(p => p.Attributes.Any(a => a.Key == key && a.Value == val));

        return query;
    }

    public static IQueryable<Product> ApplySorting(this IQueryable<Product> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Product, object>>>
        {
            ["name"] = p => p.Name,
            ["price"] = p => p.Price,
            ["rating"] = p => p.Rating,
            ["soldcount"] = p => p.SoldCount,
            ["quantity"] = p => p.Quantity,
            ["reviewscount"] = p => p.Reviews.Count
        };

        return query.ApplySorting(parameters, sortMap);
    }

    public static IQueryable<Product> ApplyCategoryVisibilityFilter(
        this IQueryable<Product> query,
        List<Guid> activeCategoryIds
    )
    {
        return query.Where(p => activeCategoryIds.Contains(p.CategoryId));
    }
}