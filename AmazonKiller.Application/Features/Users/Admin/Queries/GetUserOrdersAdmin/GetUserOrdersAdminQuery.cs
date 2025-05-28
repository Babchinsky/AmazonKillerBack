using AmazonKiller.Application.DTOs.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserOrdersAdmin;

public record GetUserOrdersAdminQuery(Guid UserId) : IRequest<List<OrderDto>>;