using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public class ProductRepository(AmazonDbContext db) : IProductRepository
{
    public Task<Product?> GetByIdAsync(Guid id)
    {
        return db.Products.Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Product product)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync();
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

    public async Task BulkDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct)
    {
        var products = await db.Products.Where(p => ids.Contains(p.Id)).ToListAsync(ct);
        db.Products.RemoveRange(products);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteRangeAsync(IEnumerable<Product> products, CancellationToken ct)
    {
        db.Products.RemoveRange(products);
        await db.SaveChangesAsync(ct);
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