using AmazonKillerBack.Application.Interfaces;
using AmazonKillerBack.Domain.Entities;
using AmazonKillerBack.Domain.Entities.Products;
using AmazonKillerBack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKillerBack.Infrastructure.Repositories;

public class ProductRepository(AmazonDbContext context) : IProductRepository
{
    public async Task<List<Product>> GetAllAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }
}
