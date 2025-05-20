using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;

public class GetCartHandler(
    ICartRepository cartRepo,
    ICurrentUserService currentUser) : IRequestHandler<GetCartQuery, List<ProductInCartDto>>
{
    public async Task<List<ProductInCartDto>> Handle(GetCartQuery request, CancellationToken ct)
    {
        var userId = currentUser.UserId!.Value;
        var cartItems = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);

        return cartItems.Select(c =>
        {
            var product = c.Product;
            var discount = product.DiscountPct ?? 0;
            var finalPrice = product.Price * (1 - discount / 100);

            return new ProductInCartDto
            {
                ProductId = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrls.FirstOrDefault() ?? "",
                Price = Math.Round(finalPrice, 2),
                Quantity = c.Quantity
            };
        }).ToList();
    }
}