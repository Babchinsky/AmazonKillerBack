using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrderDetails;

public class GetUserOrderDetailsHandler(
    IOrderRepository repo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo)
    : IRequestHandler<GetUserOrderDetailsQuery, OrderDetailsDto>
{
    public async Task<OrderDetailsDto> Handle(GetUserOrderDetailsQuery request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var result = await repo.GetOrderDetailsForUserAsync(userId, request.OrderId, ct);
        return result ?? throw new NotFoundException("Order not found");
    }
}