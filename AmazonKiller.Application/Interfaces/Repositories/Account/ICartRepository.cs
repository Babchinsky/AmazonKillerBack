using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface ICartRepository
{
    Task AddAsync(Guid userId, Guid productId, int quantity, CancellationToken ct);
    Task RemoveAsync(Guid userId, Guid productId, CancellationToken ct);
    Task UpdateQuantityAsync(Guid userId, Guid productId, int quantity, CancellationToken ct);
    Task<List<CartList>> GetCartItemsWithProductsAsync(Guid userId, CancellationToken ct);
    Task ClearCartAsync(Guid userId, CancellationToken ct);
    Task<CartList?> GetAsync(Guid userId, Guid productId, CancellationToken ct);
}