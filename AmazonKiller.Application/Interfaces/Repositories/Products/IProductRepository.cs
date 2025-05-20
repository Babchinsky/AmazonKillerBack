using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface IProductRepository
{
    // --- Чтение ---
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<bool> IsExistsAsync(Guid id);
    IQueryable<Product> Queryable();

    // --- Добавление ---
    Task AddAsync(Product product, CancellationToken ct);

    Task AddAttributesAndFeaturesAsync(List<ProductAttribute> attributes, List<ProductFeature> features,
        CancellationToken ct);

    // --- Обновление ---

    Task UpdateAsync(
        UpdateProductCommand cmd, IFileStorage files, CancellationToken ct);

    // --- Удаление ---
    Task DeleteRangeAsync(IEnumerable<Product> products, CancellationToken ct);
    Task BulkDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct);
}