using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Application.Features.Account.Orders.Queries.GetAllOrders;

public static class OrderQueryExtensions
{
    public static IQueryable<Order> ApplyFilters(this IQueryable<Order> query, GetAllOrdersQuery q)
    {
        if (q.UserId.HasValue)
            query = query.Where(o => o.UserId == q.UserId);

        if (q.Status.HasValue)
            query = query.Where(o => o.Status == q.Status.Value);

        if (string.IsNullOrWhiteSpace(q.SearchTerm)) return query;
        {
            var term = q.SearchTerm.Trim().ToLower();

            query = query.Where(o =>
                o.Info.Delivery.Email.ToLower().Contains(term) ||
                o.Info.Delivery.FirstName.ToLower().Contains(term) ||
                o.Info.Delivery.LastName.ToLower().Contains(term) ||
                o.Status.ToString().ToLower().Contains(term) ||
                o.Id.ToString().ToLower().Contains(term));
        }

        return query;
    }

    public static IQueryable<Order> ApplySorting(this IQueryable<Order> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<Order, object>>>
        {
            ["totalprice"] = o => o.TotalPrice,
            ["orderedat"] = o => o.Info.OrderedAt,
            ["status"] = o => o.Status
        };

        return query.ApplySorting(parameters, sortMap);
    }
}