using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Public.Queries.GetAllOrders;

public class GetAllOrdersQuery : IRequest<PagedList<OrderDto>>
{
    public Guid? UserId { get; init; }
    public string? SearchTerm { get; init; }
    public OrderStatus? Status { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}