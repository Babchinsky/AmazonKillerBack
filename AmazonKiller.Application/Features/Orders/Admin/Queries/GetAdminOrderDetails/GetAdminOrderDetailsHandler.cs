using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Admin.Queries.GetAdminOrderDetails;

public class GetAdminOrderDetailsHandler(IOrderRepository repo)
    : IRequestHandler<GetAdminOrderDetailsQuery, OrderDetailsDto>
{
    public async Task<OrderDetailsDto> Handle(GetAdminOrderDetailsQuery request, CancellationToken ct)
    {
        var result = await repo.GetOrderDetailsForAdminAsync(request.OrderId, ct);
        return result ?? throw new NotFoundException("Order not found");
    }
}