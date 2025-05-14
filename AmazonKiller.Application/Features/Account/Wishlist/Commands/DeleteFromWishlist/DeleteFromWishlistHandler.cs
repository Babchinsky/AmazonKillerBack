using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.DeleteFromWishlist;

public class DeleteFromWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<DeleteFromWishlistCommand>
{
    public async Task Handle(DeleteFromWishlistCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);
        await repo.DeleteAsync(userId, cmd.ProductId, ct);
    }
}