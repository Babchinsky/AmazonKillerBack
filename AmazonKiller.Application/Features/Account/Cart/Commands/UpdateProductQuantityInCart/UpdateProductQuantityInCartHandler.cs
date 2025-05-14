using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.UpdateProductQuantityInCart;

public class UpdateProductQuantityInCartHandler(
    ICurrentUserService currentUserService,
    ICartRepository cartRepo) : IRequestHandler<UpdateProductQuantityInCartCommand>
{
    public async Task Handle(UpdateProductQuantityInCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId!.Value;
        await cartRepo.UpdateQuantityAsync(userId, cmd.ProductId, cmd.Quantity, ct);
    }
}