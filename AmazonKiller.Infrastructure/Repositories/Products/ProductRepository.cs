using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.UpdateProduct;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Products;

public class ProductRepository(AmazonDbContext db) : IProductRepository
{
    public Task<Product?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Products
            .Include(p => p.Attributes)
            .Include(p => p.Features)
            .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public void AttachAndSetRowVersion(Product product, byte[] rowVersion)
    {
        var entry = db.Entry(product);
        if (entry.State == EntityState.Detached)
            db.Attach(product);

        entry.Property(p => p.RowVersion).OriginalValue = rowVersion;
        entry.Property(p => p.Name).IsModified = true;
    }

    public async Task UpdateProductAsync(Product product, UpdateProductCommand cmd, IFileStorage files,
        CancellationToken ct)
    {
        // Удаление старых изображений
        await Task.WhenAll(product.ProductPics.Select(url => files.DeleteAsync(url, ct)));

        var newPics = new List<string>();
        foreach (var image in cmd.Images)
        {
            await using var stream = image.OpenReadStream();
            var ext = Path.GetExtension(image.FileName);
            var url = await files.SaveAsync(stream, ext, ct);
            newPics.Add(url);
        }

        product.ProductPics = newPics;

        // Обновление полей
        product.Name = cmd.Name;
        product.Code = cmd.Code;
        product.CategoryId = cmd.CategoryId;
        product.Price = cmd.Price;
        product.DiscountPct = cmd.DiscountPct;
        product.Quantity = cmd.Quantity;

        // Обновление атрибутов и фичей
        product.Attributes.Clear();
        foreach (var attr in cmd.ParsedAttributes)
        {
            product.Attributes.Add(new ProductAttribute
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Key = attr.Key,
                Value = attr.Value
            });
        }

        foreach (var feat in cmd.ParsedFeatures)
        {
            product.Features.Add(new ProductFeature
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                Name = feat.Name,
                Description = feat.Description
            });
        }

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The product was modified by another user", 409);
        }
    }

    public Task SaveAsync(CancellationToken ct) => db.SaveChangesAsync(ct);

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

    public async Task UpdateAsync(Product product, byte[] originalRowVersion, CancellationToken ct)
    {
        var entry = db.Entry(product);
        entry.Property(p => p.RowVersion).OriginalValue = originalRowVersion;

        try
        {
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException("The product was modified by another user", 409);
        }
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