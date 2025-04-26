using AmazonKiller.Application.DTOs.Account;
using AmazonKiller.Domain.Entities.Orders;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IOrderRepository
{
    Task<List<OrderDto>> GetUserOrdersAsync(Guid userId, CancellationToken ct);
    Task<OrderDetailsDto> GetOrderDetailsAsync(Guid userId, Guid orderId, CancellationToken ct);
    Task<Guid> CreateOrderAsync(Order order, CancellationToken ct);
    Task AddProductToOrderAsync(Guid orderId, Guid productId, int quantity, CancellationToken ct);
    Task RemoveProductFromOrderAsync(Guid orderId, Guid productId, CancellationToken ct);
}