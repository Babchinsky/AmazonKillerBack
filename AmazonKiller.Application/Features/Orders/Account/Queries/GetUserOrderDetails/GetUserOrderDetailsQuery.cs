using AmazonKiller.Application.DTOs.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrderDetails;

public record GetUserOrderDetailsQuery(Guid OrderId) : IRequest<OrderDetailsDto>;