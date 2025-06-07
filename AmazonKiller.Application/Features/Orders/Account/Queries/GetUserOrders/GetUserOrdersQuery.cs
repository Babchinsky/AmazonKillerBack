using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Features.Orders.Common;
using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrders;

public class GetUserOrdersQuery : IRequest<PagedList<OrderDto>>, IOrderQueryWithFilters
{
    public string? SearchTerm { get; init; }
    public OrderStatus? Status { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}