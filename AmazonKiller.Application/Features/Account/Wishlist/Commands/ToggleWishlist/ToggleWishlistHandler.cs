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
        await repo.ToggleAsync(currentUser.UserId, request.ProductId, ct);
    }
}