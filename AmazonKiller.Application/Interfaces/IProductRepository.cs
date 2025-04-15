using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
}