using AmazonKiller.Application.DTOs.Account;
using AmazonKiller.Application.DTOs.Account.Wishlist;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IWishlistRepository
{
    Task AddAsync(Guid userId, Guid productId, CancellationToken ct);
    Task ToggleAsync(Guid userId, Guid productId, CancellationToken ct);
    Task<List<ProductInWishlistDto>> GetWishlistAsync(Guid userId, CancellationToken ct);
    Task DeleteAsync(Guid userId, Guid productId, CancellationToken ct);
}