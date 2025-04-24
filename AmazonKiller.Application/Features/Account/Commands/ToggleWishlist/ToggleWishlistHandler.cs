using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Commands.ToggleWishlist;

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