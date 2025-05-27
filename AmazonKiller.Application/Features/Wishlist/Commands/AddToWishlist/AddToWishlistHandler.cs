using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.AddToWishlist;

public class AddToWishlistHandler(
    IWishlistRepository wishlistRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService
) : IRequestHandler<AddToWishlistCommand>
{
    public async Task Handle(AddToWishlistCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        await wishlistRepo.AddAsync(currentUserId, cmd.ProductId, ct);
    }
}