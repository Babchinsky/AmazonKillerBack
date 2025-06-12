using AmazonKiller.Application.DTOs.Cart;
using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.AddProductToCart;

public record AddProductToCartCommand(Guid ProductId, int Quantity) : IRequest<List<CartItemDto>>;