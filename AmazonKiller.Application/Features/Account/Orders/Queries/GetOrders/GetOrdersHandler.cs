using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Queries.GetOrders;

public class GetOrdersHandler(IOrderRepository repo, ICurrentUserService currentUser)
    : IRequestHandler<GetOrdersQuery, List<OrderDto>>
{
    public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken ct)
    {
        return await repo.GetUserOrdersAsync(currentUser.UserId, ct);
    }
}