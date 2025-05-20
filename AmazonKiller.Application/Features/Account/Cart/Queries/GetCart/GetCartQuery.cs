using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;

public record GetCartQuery : IRequest<List<ProductInCartDto>>;