using System.Linq.Expressions;
using AmazonKiller.Application.Common.Models;

namespace AmazonKiller.Application.Common.Helpers;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, QueryParameters q)
    {
        return query.Skip((q.Page - 1) * q.PageSize).Take(q.PageSize);
    }

    public static IQueryable<T> ApplySorting<T>(
        this IQueryable<T> query,
        QueryParameters q,
        Dictionary<string, Expression<Func<T, object>>> sortMap)
    {
        if (string.IsNullOrWhiteSpace(q.SortBy) || !sortMap.TryGetValue(q.SortBy.ToLower(), out var sortExpr))
        {
            // fallback на Id (если есть)
            var param = Expression.Parameter(typeof(T), "x");
            var idProp = typeof(T).GetProperty("Id");
            if (idProp == null) return query;
            var idExpr = Expression.Lambda<Func<T, object>>(
                Expression.Convert(Expression.Property(param, idProp), typeof(object)), param);

            return query.OrderBy(idExpr);
        }

        var order = q.SortOrder.ToLowerInvariant();

        return order == "desc"
            ? query.OrderByDescending(sortExpr)
            : query.OrderBy(sortExpr);
    }
}