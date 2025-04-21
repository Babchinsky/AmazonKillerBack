using AmazonKiller.Application.Interfaces;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AmazonDbContext _db;
    public ProductRepository(AmazonDbContext db) => _db = db;

    public Task<List<Product>> GetAllAsync() =>
        _db.Products.Include(p => p.Details).AsNoTracking().ToListAsync();

    public Task<Product?> GetByIdAsync(Guid id) =>
        _db.Products.Include(p => p.Details).FirstOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        try
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The product was modified by another user", 409);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var p = await _db.Products.FindAsync(id);
        if (p is null) return;
        _db.Products.Remove(p);
        await _db.SaveChangesAsync();
    }

    public Task<bool> IsExistsAsync(Guid id) =>
        _db.Products.AnyAsync(p => p.Id == id);
}