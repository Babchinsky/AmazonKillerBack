using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IOrderRepository
{
    Task<List<OrderDto>> GetUserOrdersAsync(Guid userId, CancellationToken ct);
    IQueryable<Order> QueryWithIncludes();
    Task<OrderDetailsDto> GetOrderDetailsAsync(Guid userId, Guid orderId, CancellationToken ct);
    Task<Guid> CreateOrderAsync(Order order, CancellationToken ct);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus, CancellationToken ct);
}