using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Public.Queries.GetOrderDetails;

public class GetOrderDetailsHandler(
    IOrderRepository repo,
    ICurrentUserService currentUserService,
    IAccountRepository accountRepo)
    : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);
        var result = await repo.GetOrderDetailsAsync(userId, request.OrderId, ct);
        return result ?? throw new NotFoundException("Order not found");
    }
}