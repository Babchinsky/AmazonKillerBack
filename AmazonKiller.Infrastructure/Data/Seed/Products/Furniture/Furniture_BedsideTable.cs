using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;

public static class Furniture_BedsideTable
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("2ad39762-dbd2-4959-bf36-03f30e3a3a1c");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Minimalist Bedside Table",
            Code = "FUR-004",
            Price = 59.99m,
            Quantity = 40,
            CategoryId = Guid.Parse("c9f81657-73a1-4b53-bf80-b59121eae433"),
            ImageUrls = [
                "https://cdn1.jysk.com/getimage/wd3.medium/236364",
                "https://cdn1.jysk.com/getimage/wd3.medium/236369",
                "https://cdn1.jysk.com/getimage/wd3.medium/236365"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute { Id = Guid.Parse("bd929b9e-d115-41ea-8d6f-5f8c66200ac6"), ProductId = productId, Key = "Material", Value = "Engineered wood" },
            new ProductAttribute { Id = Guid.Parse("fa9b7096-d331-4ed7-a45c-80e0b5d68242"), ProductId = productId, Key = "Dimensions", Value = "45x40x50 cm" },
            new ProductAttribute { Id = Guid.Parse("2edab99b-17f7-4b63-93c2-8b42066a7d99"), ProductId = productId, Key = "Color", Value = "Oak" },
            new ProductAttribute { Id = Guid.Parse("39ecdb88-44b6-4995-8cb8-e48de889d243"), ProductId = productId, Key = "Drawers", Value = "1 soft-close drawer" }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature { Id = Guid.Parse("f2f2c8fb-0f90-420c-9ed1-5947728f615a"), ProductId = productId, Name = "Style", Description = "Modern minimalist" },
            new ProductFeature { Id = Guid.Parse("60e84a9a-e016-4654-a8e4-24e48dc26156"), ProductId = productId, Name = "Convenience", Description = "Compact storage" },
            new ProductFeature { Id = Guid.Parse("9f179493-b4d6-4a53-bdc1-d5dd3fa189e3"), ProductId = productId, Name = "Maintenance", Description = "Easy clean surface" },
            new ProductFeature { Id = Guid.Parse("e7a8d1a9-30a1-4b89-80d3-90e5a948d914"), ProductId = productId, Name = "Assembly", Description = "DIY friendly" }
        );
    }
}