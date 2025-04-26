using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.AddProductToOrder;

public record AddProductToOrderCommand(Guid OrderId, Guid ProductId, int Quantity) : IRequest;