using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;

public class GetWishlistQuery : IRequest<PagedList<ProductCardDto>>
{
    public string? SearchTerm { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}