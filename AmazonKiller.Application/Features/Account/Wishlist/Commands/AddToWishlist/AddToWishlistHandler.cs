using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.AddToWishlist;

public class AddToWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<AddToWishlistCommand>
{
    public async Task Handle(AddToWishlistCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId ?? throw new AppException("Unauthorized", 401);
        await repo.AddAsync(userId, cmd.ProductId, ct);
    }
}