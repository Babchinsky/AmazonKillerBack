using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.WorkTools;

public static class WorkTools_UtilityGloves
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("48f6ef8b-b2b2-4e33-b3f1-df7c06b60f95");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Heavy-Duty Utility Gloves",
            Code = "WTL-003",
            Price = 24.99m,
            Quantity = 80,
            CategoryId = Guid.Parse("18710447-a260-44f2-9a4b-77c0b246bbc5"),
            ImageUrls =
            [
                "https://specprom-kr.com.ua/image/cache/catalog/image/catalog/files/perchatki-mbs-pokrytye-nitrilom-tverdyj-manzhet-564x564.webp"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("8b4a31cf-9690-4cbe-a30a-5c6365ab263f"), ProductId = productId, Key = "Material",
                Value = "Synthetic leather + Spandex"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("2f4073fd-5296-4d79-90dc-2532c6795bc5"), ProductId = productId, Key = "Size",
                Value = "M, L, XL"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("c95c1143-dcb0-4010-80a0-4b260303f170"), ProductId = productId, Key = "Color",
                Value = "Black/Yellow"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("14f8a2fd-5c20-439c-b65e-bd697c9ed75a"), ProductId = productId, Key = "Closure",
                Value = "Velcro strap"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("6b747748-3a2a-4c1a-a1b3-8e7d7dbba1f1"), ProductId = productId, Name = "Grip",
                Description = "Textured palm for firm hold"
            },
            new ProductFeature
            {
                Id = Guid.Parse("34233ac6-0e32-42b1-9e4f-7c83bcd8fd5f"), ProductId = productId, Name = "Protection",
                Description = "Reinforced knuckles"
            },
            new ProductFeature
            {
                Id = Guid.Parse("de2955e6-e21e-4ed2-a65e-3b73f708dd7a"), ProductId = productId, Name = "Breathability",
                Description = "Mesh back panel"
            },
            new ProductFeature
            {
                Id = Guid.Parse("1a2ef03d-456e-4edb-a7b0-31a7088b0596"), ProductId = productId, Name = "Fit",
                Description = "Flexible and snug fit"
            }
        );
    }
}