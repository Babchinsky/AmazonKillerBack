using AmazonKiller.Application.DTOs.Account.ProductCart;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;

public record GetCartQuery() : IRequest<List<ProductInCartDto>>;