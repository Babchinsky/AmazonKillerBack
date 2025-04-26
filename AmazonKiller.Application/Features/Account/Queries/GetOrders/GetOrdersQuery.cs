using AmazonKiller.Application.DTOs.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Queries.GetOrders;

public record GetOrdersQuery : IRequest<List<OrderDto>>;