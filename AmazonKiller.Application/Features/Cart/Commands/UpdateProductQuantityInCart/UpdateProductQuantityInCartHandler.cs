using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;


namespace AmazonKiller.Application.Features.Cart.Commands.UpdateProductQuantityInCart;

public class UpdateProductQuantityInCartHandler(
    ICurrentUserService currentUserService,
    ICartRepository cartRepo,
    IAccountRepository accountRepo,
    IProductRepository productRepo) : IRequestHandler<UpdateProductQuantityInCartCommand>
{
    public async Task Handle(UpdateProductQuantityInCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var product = await productRepo.GetByIdAsync(cmd.ProductId, ct)
                      ?? throw new AppException("Product not found");

        if (cmd.Quantity > product.Quantity)
            throw new AppException($"Only {product.Quantity} items in stock");

        await cartRepo.UpdateQuantityAsync(userId, cmd.ProductId, cmd.Quantity, ct);
    }
}