using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Features.Wishlist.Queries.GetWishlist;

public static class WishlistQueryExtensions
{
    public static IQueryable<Product> ApplyWishlistFilters(this IQueryable<Product> query, string? searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm)) return query;

        var term = searchTerm.Trim().ToLower();

        return query.Where(p => p.Name.ToLower().Contains(term));
    }

    public static IQueryable<Product> ApplyWishlistSorting(this IQueryable<Product> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Product, object>>>
        {
            ["name"] = p => p.Name
        };

        return query.ApplySorting(parameters, sortMap);
    }
}