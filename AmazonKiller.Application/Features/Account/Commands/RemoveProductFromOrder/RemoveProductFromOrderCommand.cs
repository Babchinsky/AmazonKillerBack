using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.RemoveProductFromOrder;

public record RemoveProductFromOrderCommand(Guid OrderId, Guid ProductId) : IRequest;