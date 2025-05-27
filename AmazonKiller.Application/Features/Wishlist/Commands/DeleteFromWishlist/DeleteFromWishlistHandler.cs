using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Wishlist.Commands.DeleteFromWishlist;

public class DeleteFromWishlistHandler(
    IWishlistRepository wishlistRepo,
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService
) : IRequestHandler<DeleteFromWishlistCommand>
{
    public async Task Handle(DeleteFromWishlistCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        await wishlistRepo.DeleteAsync(currentUserId, cmd.ProductId, ct);
    }
}