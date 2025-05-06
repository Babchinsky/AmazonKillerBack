using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public class ProductRepository(AmazonDbContext db) : IProductRepository
{
    public Task<List<Product>> GetAllAsync()
    {
        return db.Products.Include(p => p.Details).AsNoTracking().ToListAsync();
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        return db.Products.Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        try
        {
            db.Products.Update(product);
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The product was modified by another user", 409);
        }
    }

    public async Task UpdateAsync(Product product, byte[] originalRowVersion, CancellationToken ct)
    {
        var entry = db.Entry(product);
        entry.Property(p => p.RowVersion).OriginalValue = originalRowVersion;

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The product was modified by another user", 409);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var p = await db.Products.FindAsync(id);
        if (p is null) return;
        db.Products.Remove(p);
        await db.SaveChangesAsync();
    }

    public Task BulkSoftDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct)
    {
        return db.Database.ExecuteSqlAsync(
            $"UPDATE Products SET Status = {(int)ProductStatus.OutOfStock} WHERE Id IN ({ids})", ct);
    }

    public Task<bool> IsExistsAsync(Guid id)
    {
        return db.Products.AnyAsync(p => p.Id == id);
    }

    public IQueryable<Product> Queryable()
    {
        return db.Products.Include(p => p.Details);
    }
}