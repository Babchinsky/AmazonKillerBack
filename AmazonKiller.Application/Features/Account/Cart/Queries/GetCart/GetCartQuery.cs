using AmazonKiller.Application.DTOs.Account.Cart;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;

public record GetCartQuery : IRequest<List<CartItemDto>>;