using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.DeleteFromWishlist;

public class DeleteFromWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<DeleteFromWishlistCommand>
{
    public async Task Handle(DeleteFromWishlistCommand cmd, CancellationToken ct)
    {
        await repo.DeleteAsync(currentUserService.UserId, cmd.ProductId, ct);
    }
}