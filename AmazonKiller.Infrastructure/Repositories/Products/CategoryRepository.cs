using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public class CategoryRepository(AmazonDbContext db) : ICategoryRepository
{
    // ---- дерево -------------------------------------------------
    public Task<List<Category>> GetTreeAsync(CancellationToken ct)
    {
        return db.Categories
            .Include(c => c.Children.OrderBy(x => x.Name))
            .Where(c => c.ParentId == null)
            .OrderBy(c => c.Name)
            .ToListAsync(ct);
    }

    public async Task<List<Guid>> GetDescendantIdsAsync(Guid rootId, CancellationToken ct)
    {
        var sql = $"""
                   WITH cte AS (
                       SELECT Id FROM Categories WHERE Id = '{rootId}'
                       UNION ALL
                       SELECT c.Id FROM Categories c
                       JOIN cte ON c.ParentId = cte.Id
                   )
                   SELECT Id FROM cte
                   """;

        return await db.Database.SqlQueryRaw<Guid>(sql).ToListAsync(ct);
    }

    // ---- CRUD ---------------------------------------------------
    public Task<List<Category>> GetAllAsync(CancellationToken ct)
    {
        return db.Categories.AsNoTracking().ToListAsync(ct);
    }

    public Task<Category?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public Task<bool> IsExistsAsync(Guid id, CancellationToken ct)
    {
        return db.Categories.AnyAsync(c => c.Id == id, ct);
    }

    public async Task AddAsync(Category c, CancellationToken ct)
    {
        db.Categories.Add(c);
        await db.SaveChangesAsync(ct);
    }

    public Task UpdateAsync(Category c, CancellationToken ct)
    {
        db.Categories.Update(c);
        return db.SaveChangesAsync(ct);
    }

    public async Task SoftDeleteAsync(Guid id, CancellationToken ct)
    {
        var c = await db.Categories.FindAsync([id], ct);
        if (c is null) return;
        c.Status = CategoryStatus.NotActive;
        await db.SaveChangesAsync(ct);
    }

    public async Task BulkSoftDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct)
    {
        var cats = await db.Categories.Where(c => ids.Contains(c.Id)).ToListAsync(ct);
        cats.ForEach(c => c.Status = CategoryStatus.NotActive);
        await db.SaveChangesAsync(ct);
    }
}