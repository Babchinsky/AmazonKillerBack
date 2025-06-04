using AmazonKiller.Application.DTOs.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserOrders;

public record GetUserOrdersQuery(Guid UserId) : IRequest<List<OrderDto>>;