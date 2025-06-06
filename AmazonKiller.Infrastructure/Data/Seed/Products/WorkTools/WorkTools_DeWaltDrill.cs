using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.WorkTools;

public static class WorkTools_DeWaltDrill
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("3c7b48ff-2b17-456e-b6d9-1e4701c56ab2");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "DeWalt DCD996 Cordless Drill",
            Code = "WTL-002",
            Price = 199.99m,
            Quantity = 60,
            CategoryId = Guid.Parse("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
            ImageUrls =
            [
                "https://content2.rozetka.com.ua/goods/images/big/11956995.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("f31206e4-8237-4db1-b3a0-544b26dd5865"), ProductId = productId, Key = "Voltage",
                Value = "20V"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("b8bc8f7a-267f-43a8-b81e-360d250209c3"), ProductId = productId, Key = "Speed",
                Value = "0–2000 RPM"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("f5035e59-f0f6-4db6-8160-0df17931a1c8"), ProductId = productId, Key = "Battery",
                Value = "2x 5.0Ah Li-ion"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("6c6b5864-33a0-4ec0-9a7e-34d73d226289"), ProductId = productId, Key = "Chuck Size",
                Value = "13mm"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("1e4cc7b4-51a5-4bfb-8e36-1ce9a2a6c8b0"), ProductId = productId, Name = "Performance",
                Description = "Brushless motor"
            },
            new ProductFeature
            {
                Id = Guid.Parse("2a222bb7-cc32-4e2f-9ad3-2ad2aaf1fc6f"), ProductId = productId, Name = "Durability",
                Description = "Heavy-duty construction"
            },
            new ProductFeature
            {
                Id = Guid.Parse("6ab182fd-45bb-4747-93d7-4533cdd9f88c"), ProductId = productId, Name = "Convenience",
                Description = "LED work light"
            },
            new ProductFeature
            {
                Id = Guid.Parse("1c6c2255-9535-4520-84ee-b00db4a2225d"), ProductId = productId, Name = "Grip",
                Description = "Ergonomic handle"
            }
        );
    }
}