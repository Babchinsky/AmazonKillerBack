using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Queries.GetOrderDetails;

public class GetOrderDetailsHandler(IOrderRepository repo, ICurrentUserService currentUser)
    : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken ct)
    {
        if (currentUser.UserId is not { } userId)
            throw new UnauthorizedAccessException();

        var result = await repo.GetOrderDetailsAsync(userId, request.OrderId, ct);
        return result ?? throw new NotFoundException("Order not found");
    }
}