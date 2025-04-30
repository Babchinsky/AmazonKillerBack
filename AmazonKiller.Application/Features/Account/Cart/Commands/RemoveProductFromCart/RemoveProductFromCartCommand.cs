using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.RemoveProductFromCart;

public record RemoveProductFromCartCommand(Guid ProductId) : IRequest;