using AmazonKiller.Application.DTOs.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Admin.Queries.GetAdminOrderDetails;

public record GetAdminOrderDetailsQuery(Guid OrderId) : IRequest<OrderDetailsDto>;