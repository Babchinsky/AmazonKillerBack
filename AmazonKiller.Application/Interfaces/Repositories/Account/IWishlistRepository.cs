using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Account;

public interface IWishlistRepository
{
    Task AddAsync(Guid userId, Guid productId, CancellationToken ct);
    Task ToggleAsync(Guid userId, Guid productId, CancellationToken ct);

    Task<PagedList<ProductCardDto>> GetWishlistAsync(
        Guid userId, string? searchTerm, QueryParameters parameters, CancellationToken ct);

    Task DeleteAsync(Guid userId, Guid productId, CancellationToken ct);
}