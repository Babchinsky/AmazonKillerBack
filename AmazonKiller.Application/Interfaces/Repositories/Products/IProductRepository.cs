using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Application.Interfaces.Services;

namespace AmazonKiller.Application.Interfaces.Repositories.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct);

    /// <summary>
    /// Полное обновление продукта с оптимистичной блокировкой и полной заменой коллекций.
    /// </summary>
    /// <param name="cmd">Команда с данными для обновления</param>
    /// <param name="files">Файловое хранилище для работы с изображениями</param>
    /// <param name="ct">Токен отмены</param>
    Task UpdateAsync(UpdateProductCommand cmd, IFileStorage files, CancellationToken ct);

    Task AddAsync(Product product, CancellationToken ct);

    Task AddAttributesAndFeaturesAsync(
        List<ProductAttribute> attributes,
        List<ProductFeature> features,
        CancellationToken ct);

    Task BulkDeleteAsync(IEnumerable<Guid> ids, CancellationToken ct);

    Task DeleteRangeAsync(IEnumerable<Product> products, CancellationToken ct);

    Task<bool> IsExistsAsync(Guid id);

    IQueryable<Product> Queryable();
}