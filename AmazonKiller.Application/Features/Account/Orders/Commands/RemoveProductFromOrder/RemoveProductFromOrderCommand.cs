using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.RemoveProductFromOrder;

public record RemoveProductFromOrderCommand(Guid OrderId, Guid ProductId) : IRequest;