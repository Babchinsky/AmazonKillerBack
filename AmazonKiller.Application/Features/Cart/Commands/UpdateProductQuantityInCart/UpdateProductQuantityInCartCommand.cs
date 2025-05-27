using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.UpdateProductQuantityInCart;

public record UpdateProductQuantityInCartCommand(Guid ProductId, int Quantity) : IRequest;