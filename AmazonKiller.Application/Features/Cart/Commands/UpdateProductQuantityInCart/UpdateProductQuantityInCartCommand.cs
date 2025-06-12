using AmazonKiller.Application.DTOs.Cart;
using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.UpdateProductQuantityInCart;

public record UpdateProductQuantityInCartCommand(Guid ProductId, int Quantity) : IRequest<List<CartItemDto>>;