using AmazonKiller.Application.DTOs.Account.Wishlist;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Queries.GetWishlist;

public class GetWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<GetWishlistQuery, List<ProductInWishlistDto>>
{
    public async Task<List<ProductInWishlistDto>> Handle(GetWishlistQuery request, CancellationToken ct)
    {
        return await repo.GetWishlistAsync(currentUserService.UserId, ct);
    }
}