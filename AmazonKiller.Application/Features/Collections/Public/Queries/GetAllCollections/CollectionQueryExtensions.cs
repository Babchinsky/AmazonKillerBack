using System.Linq.Expressions;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Application.Common.Helpers;

namespace AmazonKiller.Application.Features.Collections.Public.Queries.GetAllCollections;

public static class CollectionQueryExtensions
{
    public static IQueryable<Collection> ApplyFilters(
        this IQueryable<Collection> query,
        string? searchTerm,
        Guid? categoryId,
        decimal? minPrice,
        decimal? maxPrice)
    {
        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            var term = searchTerm.Trim().ToLower();
            query = query.Where(c => c.Title.ToLower().Contains(term));
        }

        if (categoryId.HasValue)
            query = query.Where(c => c.CategoryId == categoryId);

        if (minPrice.HasValue)
            query = query.Where(c => !c.MinPrice.HasValue || c.MinPrice >= minPrice);

        if (maxPrice.HasValue)
            query = query.Where(c => !c.MaxPrice.HasValue || c.MaxPrice <= maxPrice);

        return query;
    }

    public static IQueryable<Collection> ApplySorting(
        this IQueryable<Collection> query,
        QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Collection, object>>>
        {
            ["title"] = c => c.Title,
            ["minprice"] = c => c.MinPrice ?? 0,
            ["maxprice"] = c => c.MaxPrice ?? 0
        };

        return query.ApplySorting(parameters, sortMap);
    }
}