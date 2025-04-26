using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.AddProductToOrder;

public record AddProductToOrderCommand(Guid OrderId, Guid ProductId, int Quantity) : IRequest;