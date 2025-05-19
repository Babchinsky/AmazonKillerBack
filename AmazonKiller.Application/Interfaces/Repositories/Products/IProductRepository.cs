using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<bool> IsExistsAsync(Guid id);
    Task AddAsync(Product product, CancellationToken ct);
    Task UpdateAsync(Product product, byte[] originalRowVersion, CancellationToken ct);
    Task DeleteRangeAsync(IEnumerable<Product> products, CancellationToken ct);
    Task BulkDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct);
    IQueryable<Product> Queryable();
}