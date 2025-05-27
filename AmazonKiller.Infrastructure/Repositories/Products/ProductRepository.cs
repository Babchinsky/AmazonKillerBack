using AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public sealed class ProductRepository(AmazonDbContext db, IFileStorage fileStorage) : IProductRepository
{
    private static async Task<List<string>> SaveAllAsync(IEnumerable<IFormFile> files,
        IFileStorage fs,
        CancellationToken ct)
    {
        var urls = new List<string>();
        foreach (var f in files)
        {
            await using var s = f.OpenReadStream();
            urls.Add(await fs.SaveAsync(s, Path.GetExtension(f.FileName), ct));
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
    /// Полное обновление продукта (EF Core 7 bulk-API) c проверкой RowVersion.
    /// </summary>
    public async Task UpdateAsync(UpdateProductCommand cmd,
        IFileStorage fs,
        CancellationToken ct)
    {
        var oldRv = Convert.FromBase64String(cmd.RowVersion);

        /* 0-a.  Сохраняем ПРЕЖНИЙ список картинок------------------------- */
        var oldUrls = await db.Products.AsNoTracking()
            .Where(p => p.Id == cmd.Id)
            .SelectMany(p => p.ImageUrls)
            .ToListAsync(ct);

        /* 0-b.  Загружаем НОВЫЕ файлы -------------------------------------- */
        var newUrls = await SaveAllAsync(cmd.Images, fs, ct);

        await using var tx = await db.Database.BeginTransactionAsync(ct);

        /* 1.  Обновляем «плоские» поля + ImageUrls + проверяем RowVersion -- */
        var rows = await db.Products
            .Where(p => p.Id == cmd.Id && p.RowVersion == oldRv)
            .ExecuteUpdateAsync(set => set
                .SetProperty(p => p.Name, cmd.Name)
                .SetProperty(p => p.Code, cmd.Code)
                .SetProperty(p => p.CategoryId, cmd.CategoryId)
                .SetProperty(p => p.Price, cmd.Price)
                .SetProperty(p => p.DiscountPercent, cmd.DiscountPercent)
                .SetProperty(p => p.Quantity, cmd.Quantity)
                .SetProperty(p => p.ImageUrls, newUrls), ct);

        if (rows == 0)
        {
            await fs.DeleteBatchSafeAsync(newUrls, ct); // откат
            throw new AppException("The product was modified by another user", 409);
        }

        /* 2.  Пересоздаём Attributes / Features (как раньше) --------------- */
        await db.ProductAttributes.Where(a => a.ProductId == cmd.Id)
            .ExecuteDeleteAsync(ct);
        await db.ProductFeatures.Where(f => f.ProductId == cmd.Id)
            .ExecuteDeleteAsync(ct);

        var attrs = cmd.ParsedAttributes.Select(a => new ProductAttribute
        {
            Id = Guid.NewGuid(), ProductId = cmd.Id, Key = a.Key, Value = a.Value
        });
        var feats = cmd.ParsedFeatures.Select(f => new ProductFeature
        {
            Id = Guid.NewGuid(), ProductId = cmd.Id, Name = f.Name, Description = f.Description
        });

        await db.ProductAttributes.AddRangeAsync(attrs, ct);
        await db.ProductFeatures.AddRangeAsync(feats, ct);

        await db.SaveChangesAsync(ct);
        await tx.CommitAsync(ct);

        /* 3.  Удаляем ФАКТИЧЕСКИ устаревшие картинки ----------------------- */
        var urlsToDelete = oldUrls.Except(newUrls, StringComparer.OrdinalIgnoreCase);
        await fs.DeleteBatchSafeAsync(urlsToDelete.ToList(), ct);
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
        await DeleteRangeAsync(products, ct);
    }

    public async Task DeleteRangeAsync(IEnumerable<Product> products, CancellationToken ct)
    {
        var enumerable = products.ToList();
        var imagesToDelete = enumerable.SelectMany(p => p.ImageUrls).ToList();

        db.Products.RemoveRange(enumerable);
        await db.SaveChangesAsync(ct);

        await fileStorage.DeleteBatchSafeAsync(imagesToDelete, ct);
    }

    public Task<bool> IsExistsAsync(Guid id)
    {
        return db.Products.AnyAsync(p => p.Id == id);
    }

    public IQueryable<Product> Queryable()
    {
        return db.Products.AsQueryable();
    }
}