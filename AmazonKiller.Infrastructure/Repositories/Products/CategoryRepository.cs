using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Categories;
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

    public async Task DeleteRangeAsync(IEnumerable<Category> categories, CancellationToken ct)
    {
        db.Categories.RemoveRange(categories);
        await db.SaveChangesAsync(ct);
    }
}