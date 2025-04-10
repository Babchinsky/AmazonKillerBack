using AmazonKillerBack.Domain.Entities;

namespace AmazonKillerBack.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
}