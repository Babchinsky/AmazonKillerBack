using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;

public static class Furniture_OfficeChair
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("8888aaaa-bbbb-cccc-dddd-eeee00000002");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Ergonomic Office Chair with Lumbar Support",
            Code = "FUR-003",
            Price = 249.99m,
            Quantity = 50,
            CategoryId = Guid.Parse("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"),
            ImageUrls =
            [
                "https://kupistul.ua/public/upload/catalogGood/kreslo-flex-mesh-cherniy-cherniy-106850112-0995.jpg",
                "https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77445.jpg",
                "https://kupistul.ua/public/upload/catalogGoodPhoto/kreslo-flex-mesh-cherniy-cherniy-106850112-77446.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000321"), ProductId = productId, Key = "Material", Value = "Mesh + Foam" },
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000322"), ProductId = productId, Key = "Color", Value = "Black" },
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000323"), ProductId = productId, Key = "Adjustable Height", Value = "Yes" },
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000324"), ProductId = productId, Key = "Max Weight", Value = "120 kg" }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature { Id = Guid.Parse("00000000-0000-0000-0000-000000000421"), ProductId = productId, Name = "Ergonomic Design", Description = "Provides lumbar support and breathable mesh back" },
            new ProductFeature { Id = Guid.Parse("00000000-0000-0000-0000-000000000422"), ProductId = productId, Name = "Mobility", Description = "360° swivel and smooth rolling wheels" },
            new ProductFeature { Id = Guid.Parse("00000000-0000-0000-0000-000000000423"), ProductId = productId, Name = "Adjustability", Description = "Adjustable height and tilt tension" }
        );
    }
}
