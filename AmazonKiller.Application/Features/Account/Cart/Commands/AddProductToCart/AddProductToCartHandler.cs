using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Commands.AddProductToCart;

public class AddProductToCartHandler(
    ICurrentUserService currentUserService,
    ICartRepository cartRepo) : IRequestHandler<AddProductToCartCommand>
{
    public async Task Handle(AddProductToCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId!.Value;

        var existing = await cartRepo.GetAsync(userId, cmd.ProductId, ct);

        if (existing != null)
            // Суммируем количество
            await cartRepo.UpdateQuantityAsync(userId, cmd.ProductId, existing.Quantity + cmd.Quantity, ct);
        else
            await cartRepo.AddAsync(userId, cmd.ProductId, cmd.Quantity, ct);
    }
}