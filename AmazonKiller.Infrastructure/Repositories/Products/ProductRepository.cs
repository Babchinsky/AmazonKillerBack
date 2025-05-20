using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public class ProductRepository(AmazonDbContext db) : IProductRepository
{
    private static async Task<List<string>> UploadAllAsync(
        IEnumerable<IFormFile> files,
        IFileStorage storage,
        CancellationToken ct)
    {
        var urls = new List<string>();

        foreach (var img in files)
        {
            await using var s = img.OpenReadStream();
            var url = await storage.SaveAsync(s, Path.GetExtension(img.FileName), ct);
            urls.Add(url);
        }

        return urls;
    }

    public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Products
            .Include(p => p.Attributes)
            .Include(p => p.Features)
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    /// <summary>
    /// Полное обновление продукта c оптимистичной блокировкой.
    /// EF Core 7 – используют bulk-API ExecuteUpdate / ExecuteDelete.
    /// </summary>
    public async Task UpdateAsync(
        UpdateProductCommand cmd,
        IFileStorage fileStorage,
        CancellationToken ct)
    {
        var oldRowVersion = Convert.FromBase64String(cmd.RowVersion);

        await using var tx = await db.Database.BeginTransactionAsync(ct);

        /********** 1. Обновляем «простые» поля *********************************/

        var affected = await db.Products
            .Where(p => p.Id == cmd.Id &&
                        p.RowVersion == oldRowVersion) // concurrency-check
            .ExecuteUpdateAsync(set => set
                .SetProperty(p => p.Name, cmd.Name)
                .SetProperty(p => p.Code, cmd.Code)
                .SetProperty(p => p.CategoryId, cmd.CategoryId)
                .SetProperty(p => p.Price, cmd.Price)
                .SetProperty(p => p.DiscountPct, cmd.DiscountPct)
                .SetProperty(p => p.Quantity, cmd.Quantity), ct);

        if (affected == 0)
            throw new AppException("The product was modified by another user", 409);

        /********** 2. Attributes ************************************************/

        await db.ProductAttributes
            .Where(a => a.ProductId == cmd.Id)
            .ExecuteDeleteAsync(ct);

        var newAttrs = cmd.ParsedAttributes.Select(a => new ProductAttribute
        {
            Id = Guid.NewGuid(),
            ProductId = cmd.Id,
            Key = a.Key,
            Value = a.Value
        }).ToList();

        await db.ProductAttributes.AddRangeAsync(newAttrs, ct);

        /********** 3. Features **************************************************/

        await db.ProductFeatures
            .Where(f => f.ProductId == cmd.Id)
            .ExecuteDeleteAsync(ct);

        var newFeatures = cmd.ParsedFeatures.Select(f => new ProductFeature
        {
            Id = Guid.NewGuid(),
            ProductId = cmd.Id,
            Name = f.Name,
            Description = f.Description
        }).ToList();

        await db.ProductFeatures.AddRangeAsync(newFeatures, ct);

        /********** 4. Картинки **************************************************/

        // забираем список url-ов без трекинга => не заводим вторую копию Product
        var oldUrls = await db.Products
            .Where(p => p.Id == cmd.Id)
            .SelectMany(p => p.ImageUrls)
            .AsNoTracking()
            .ToListAsync(ct);

        await Task.WhenAll(oldUrls.Select(u => fileStorage.DeleteAsync(u, ct)));

        var newUrls = await UploadAllAsync(cmd.Images, fileStorage, ct);

        await db.Products
            .Where(p => p.Id == cmd.Id)
            .ExecuteUpdateAsync(set => set
                .SetProperty(p => p.ImageUrls, newUrls), ct);

        /********** 5. Завершаем *************************************************/

        await db.SaveChangesAsync(ct); // сохранит вставленные коллекции
        await tx.CommitAsync(ct); // фиксируем изменения + новый RowVersion
    }

    public async Task AddAsync(Product product, CancellationToken ct)
    {
        db.Products.Add(product);
        await db.SaveChangesAsync(ct);
    }

    public async Task AddAttributesAndFeaturesAsync(
        List<ProductAttribute> attributes,
        List<ProductFeature> features,
        CancellationToken ct)
    {
        db.ProductAttributes.AddRange(attributes);
        db.ProductFeatures.AddRange(features);
        await db.SaveChangesAsync(ct);
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
        return db.Products;
    }
}