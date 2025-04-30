using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.UpdateProductQuantityInCart;

public record UpdateProductQuantityInCartCommand(Guid ProductId, int Quantity) : IRequest;