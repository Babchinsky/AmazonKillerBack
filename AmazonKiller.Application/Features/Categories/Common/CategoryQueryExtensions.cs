using System.Linq.Expressions;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Application.Common.Helpers;

namespace AmazonKiller.Application.Features.Categories.Common;

public static class CategoryQueryExtensions
{
    public static IQueryable<Category> ApplySorting(this IQueryable<Category> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Category, object>>>
        {
            ["name"] = c => c.Name,
        };

        return query.ApplySorting(parameters, sortMap);
    }
}