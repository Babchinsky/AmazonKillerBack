using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;
using AutoMapper;
using AmazonKiller.Application.DTOs.Cart;

namespace AmazonKiller.Application.Features.Cart.Commands.RemoveProductFromCart;

public class RemoveProductFromCartHandler(
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo,
    ICartRepository cartRepo,
    IMapper mapper
) : IRequestHandler<RemoveProductFromCartCommand, List<CartItemDto>>
{
    public async Task<List<CartItemDto>> Handle(RemoveProductFromCartCommand cmd, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);
        await cartRepo.RemoveAsync(userId, cmd.ProductId, ct);

        var items = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);
        return mapper.Map<List<CartItemDto>>(items);
    }
}