using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.RemoveProductFromCart;

public class RemoveProductFromCartHandler(ICurrentUserService currentUserService, ICartRepository cartRepo)
    : IRequestHandler<RemoveProductFromCartCommand>
{
    public async Task Handle(RemoveProductFromCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await cartRepo.RemoveAsync(userId, cmd.ProductId, ct);
    }
}