using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Wishlist.Commands.AddToWishlist;

public class AddToWishlistHandler(
    IWishlistRepository repo,
    ICurrentUserService currentUserService
) : IRequestHandler<AddToWishlistCommand>
{
    public async Task Handle(AddToWishlistCommand cmd, CancellationToken ct)
    {
        await repo.AddAsync(currentUserService.UserId, cmd.ProductId, ct);
    }
}