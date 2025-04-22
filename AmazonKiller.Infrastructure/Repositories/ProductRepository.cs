using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories;

public class ProductRepository(AmazonDbContext db) : IProductRepository
{
    public Task<List<Product>> GetAllAsync() =>
        db.Products.Include(p => p.Details).AsNoTracking().ToListAsync();

    public Task<Product?> GetByIdAsync(Guid id) =>
        db.Products.Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);

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

    public async Task DeleteAsync(Guid id)
    {
        var p = await db.Products.FindAsync(id);
        if (p is null) return;
        db.Products.Remove(p);
        await db.SaveChangesAsync();
    }

    public Task<bool> IsExistsAsync(Guid id) =>
        db.Products.AnyAsync(p => p.Id == id);
    
    public IQueryable<Product> Queryable() =>
        db.Products.Include(p => p.Details);
}