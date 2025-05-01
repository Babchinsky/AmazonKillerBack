using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetUserOrdersAdmin;

public class GetUserOrdersAdminHandler(IOrderRepository repo)
    : IRequestHandler<GetUserOrdersAdminQuery, List<OrderDto>>
{
    public Task<List<OrderDto>> Handle(GetUserOrdersAdminQuery request, CancellationToken ct)
    {
        return repo.GetUserOrdersAsync(request.UserId, ct);
    }
}