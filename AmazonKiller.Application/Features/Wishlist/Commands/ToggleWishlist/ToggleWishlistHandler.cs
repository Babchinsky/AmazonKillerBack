using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.ToggleWishlist;

public class ToggleWishlistHandler(
    IWishlistRepository wishlistRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService)
    : IRequestHandler<ToggleWishlistCommand>
{
    public async Task Handle(ToggleWishlistCommand request, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        await wishlistRepo.ToggleAsync(currentUserId, request.ProductId, ct);
    }
}