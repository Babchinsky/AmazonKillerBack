using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;

public class GetWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<GetWishlistQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetWishlistQuery request, CancellationToken ct)
    {
        return await repo.GetWishlistAsync(
            currentUserService.UserId,
            request.SearchTerm,
            request.Parameters,
            ct
        );
    }
}