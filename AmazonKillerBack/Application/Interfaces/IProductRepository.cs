using AmazonKillerBack.Domain.Entities;
using AmazonKillerBack.Domain.Entities.Products;

namespace AmazonKillerBack.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
}