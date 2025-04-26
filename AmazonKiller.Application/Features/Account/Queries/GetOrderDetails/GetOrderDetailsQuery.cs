using AmazonKiller.Application.DTOs.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Queries.GetOrderDetails;

public record GetOrderDetailsQuery(Guid OrderId) : IRequest<OrderDetailsDto>;