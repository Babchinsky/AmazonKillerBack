using AmazonKiller.Application.DTOs.Account.Wishlist;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;

public record GetWishlistQuery : IRequest<List<ProductInWishlistDto>>;