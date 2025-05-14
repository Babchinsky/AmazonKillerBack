using AmazonKiller.Application.DTOs.Account.ProductCart;
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

        return cartItems.Select(c => new ProductInCartDto
        {
            ProductId = c.Product.Id,
            Name = c.Product.Name,
            ImageUrl = c.Product.ProductPics.FirstOrDefault() ?? "",
            Price = c.Product.Sale?.NewPrice ?? c.Product.Price,
            Quantity = c.Quantity
        }).ToList();
    }
}