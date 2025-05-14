using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.ToggleWishlist;

public class ToggleWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUser)
    : IRequestHandler<ToggleWishlistCommand>
{
    public async Task Handle(ToggleWishlistCommand request, CancellationToken ct)
    {
        if (currentUser.UserId is not { } userId)
            throw new UnauthorizedAccessException("User not authenticated");

        await repo.ToggleAsync(userId, request.ProductId, ct);
    }
}