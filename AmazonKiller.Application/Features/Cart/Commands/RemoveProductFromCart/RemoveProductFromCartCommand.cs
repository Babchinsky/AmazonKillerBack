using AmazonKiller.Application.DTOs.Cart;
using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.RemoveProductFromCart;

public record RemoveProductFromCartCommand(Guid ProductId) : IRequest<List<CartItemDto>>;