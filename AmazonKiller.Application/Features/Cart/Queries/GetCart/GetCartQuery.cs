using AmazonKiller.Application.DTOs.Cart;
using MediatR;

namespace AmazonKiller.Application.Features.Cart.Queries.GetCart;

public record GetCartQuery : IRequest<List<CartItemDto>>;