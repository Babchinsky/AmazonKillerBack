using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Features.Orders.Common;
using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Admin.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<PagedList<OrderDto>>, IOrderQueryWithFilters
{
    public Guid? UserId { get; init; } // Admin-only
    public string? SearchTerm { get; init; }
    public OrderStatus? Status { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}