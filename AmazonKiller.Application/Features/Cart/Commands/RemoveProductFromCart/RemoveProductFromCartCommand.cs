using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.RemoveProductFromCart;

public record RemoveProductFromCartCommand(Guid ProductId) : IRequest;