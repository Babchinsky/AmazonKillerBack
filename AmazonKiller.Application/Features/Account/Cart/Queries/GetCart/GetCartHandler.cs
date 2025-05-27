using AmazonKiller.Application.DTOs.Account.Cart;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Cart.Queries.GetCart;

public class GetCartHandler(
    ICartRepository cartRepo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    IMapper mapper) : IRequestHandler<GetCartQuery, List<CartItemDto>>
{
    public async Task<List<CartItemDto>> Handle(GetCartQuery request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);
        var cartItems = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);

        return mapper.Map<List<CartItemDto>>(
            cartItems.Select(c => (c.Product, c.Quantity)).ToList());
    }
}