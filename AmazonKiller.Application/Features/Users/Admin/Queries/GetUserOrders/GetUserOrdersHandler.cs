using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserOrders;

public class GetUserOrdersHandler(IOrderRepository repo)
    : IRequestHandler<GetUserOrdersQuery, List<OrderDto>>
{
    public Task<List<OrderDto>> Handle(GetUserOrdersQuery request, CancellationToken ct)
    {
        return repo.GetUserOrdersAsync(request.UserId, ct);
    }
}