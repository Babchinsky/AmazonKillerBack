using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface ICategoryRepository
{
    Task<List<Category>> GetTreeAsync(CancellationToken ct);

    // ---- CRUD ---------------------------------------------------
    Task<List<Category>> GetAllAsync(CancellationToken ct);
    Task<Category?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<bool> IsExistsAsync(Guid id, CancellationToken ct);

    Task AddAsync(Category c, CancellationToken ct);
    Task UpdateAsync(Category c, CancellationToken ct);
    Task DeleteRangeAsync(IEnumerable<Category> categories, CancellationToken ct);
}