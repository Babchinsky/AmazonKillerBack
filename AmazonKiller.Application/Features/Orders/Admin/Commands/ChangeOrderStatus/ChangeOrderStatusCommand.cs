using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Admin.Commands.ChangeOrderStatus;

public class ChangeOrderStatusCommand : IRequest
{
    public Guid OrderId { get; init; }
    public OrderStatus NewStatus { get; init; }
}