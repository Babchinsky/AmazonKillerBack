using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface ICategoryRepository
{
    Task<List<Category>> GetTreeAsync(CancellationToken ct);
    Task<List<Guid>> GetDescendantIdsAsync(Guid rootId, CancellationToken ct);

    // ---- CRUD ---------------------------------------------------
    Task<List<Category>> GetAllAsync(CancellationToken ct);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<bool> IsExistsAsync(Guid id, CancellationToken ct);

    Task AddAsync(Category c, CancellationToken ct);
    Task UpdateAsync(Category c, CancellationToken ct);
    Task SoftDeleteAsync(Guid id, CancellationToken ct);
    Task BulkSoftDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct);
}