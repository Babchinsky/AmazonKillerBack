using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Queries.GetWishlist;

public class GetWishlistHandler(
    IWishlistRepository wishlistRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService
) : IRequestHandler<GetWishlistQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetWishlistQuery request, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        return await wishlistRepo.GetWishlistAsync(
            currentUserId,
            request.SearchTerm,
            request.Parameters,
            ct
        );
    }
}