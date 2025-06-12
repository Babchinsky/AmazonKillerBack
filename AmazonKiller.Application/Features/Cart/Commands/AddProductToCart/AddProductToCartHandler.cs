using AmazonKiller.Application.DTOs.Cart;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Cart.Commands.AddProductToCart;

public class AddProductToCartHandler(
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    ICartRepository cartRepo,
    IProductRepository productRepo,
    IMapper mapper) : IRequestHandler<AddProductToCartCommand, List<CartItemDto>>
{
    public async Task<List<CartItemDto>> Handle(AddProductToCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var product = await productRepo.GetByIdAsync(cmd.ProductId, ct)
                      ?? throw new AppException("Product not found");

        var existing = await cartRepo.GetAsync(userId, cmd.ProductId, ct);
        var totalRequested = (existing?.Quantity ?? 0) + cmd.Quantity;

        if (totalRequested > product.Quantity)
            throw new AppException($"Only {product.Quantity} items in stock");

        if (existing != null)
            await cartRepo.UpdateQuantityAsync(userId, cmd.ProductId, totalRequested, ct);
        else
            await cartRepo.AddAsync(userId, cmd.ProductId, cmd.Quantity, ct);
        
        var items = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);
        return mapper.Map<List<CartItemDto>>(items);
    }
}