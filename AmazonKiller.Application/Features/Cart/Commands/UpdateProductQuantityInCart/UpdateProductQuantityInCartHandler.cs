using AmazonKiller.Application.DTOs.Cart;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;


namespace AmazonKiller.Application.Features.Cart.Commands.UpdateProductQuantityInCart;

public class UpdateProductQuantityInCartHandler(
    ICurrentUserService currentUserService,
    ICartRepository cartRepo,
    IAccountRepository accountRepo,
    IProductRepository productRepo,
    IMapper mapper
) : IRequestHandler<UpdateProductQuantityInCartCommand, List<CartItemDto>>
{
    public async Task<List<CartItemDto>> Handle(UpdateProductQuantityInCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var product = await productRepo.GetByIdAsync(cmd.ProductId, ct)
                      ?? throw new AppException("Product not found");

        if (cmd.Quantity > product.Quantity)
            throw new AppException($"Only {product.Quantity} items in stock");

        await cartRepo.UpdateQuantityAsync(userId, cmd.ProductId, cmd.Quantity, ct);

        var items = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);
        return mapper.Map<List<CartItemDto>>(items);
    }
}