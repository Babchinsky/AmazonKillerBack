using AmazonKiller.Application.DTOs.Account.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Queries.GetOrderDetails;

public record GetOrderDetailsQuery(Guid OrderId) : IRequest<OrderDetailsDto>;