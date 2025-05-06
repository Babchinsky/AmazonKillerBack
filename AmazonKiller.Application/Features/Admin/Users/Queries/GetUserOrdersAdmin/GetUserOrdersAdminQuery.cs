using AmazonKiller.Application.DTOs.Account.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetUserOrdersAdmin;

public record GetUserOrdersAdminQuery(Guid UserId) : IRequest<List<OrderDto>>;