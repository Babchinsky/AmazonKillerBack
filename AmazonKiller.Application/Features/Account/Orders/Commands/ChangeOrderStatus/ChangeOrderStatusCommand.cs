using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace  AmazonKiller.Application.Features.Account.Orders.Commands.ChangeOrderStatus;

public class ChangeOrderStatusCommand : IRequest
{
    public Guid OrderId { get; init; }
    public OrderStatus NewStatus { get; init; }
}