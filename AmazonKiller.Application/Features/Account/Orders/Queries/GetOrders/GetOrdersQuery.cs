using AmazonKiller.Application.DTOs.Account.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Queries.GetOrders;

public record GetOrdersQuery : IRequest<List<OrderDto>>;