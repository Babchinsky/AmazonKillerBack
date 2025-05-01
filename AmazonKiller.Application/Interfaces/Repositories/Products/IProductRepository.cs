using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<bool> IsExistsAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Product product, byte[] originalRowVersion, CancellationToken ct);
    Task BulkSoftDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct);
    IQueryable<Product> Queryable();
}