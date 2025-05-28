using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserOrdersAdmin;

public class GetUserOrdersAdminHandler(IOrderRepository repo)
    : IRequestHandler<GetUserOrdersAdminQuery, List<OrderDto>>
{
    public Task<List<OrderDto>> Handle(GetUserOrdersAdminQuery request, CancellationToken ct)
    {
        return repo.GetUserOrdersAsync(request.UserId, ct);
    }
}