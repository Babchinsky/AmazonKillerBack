using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Household;

public static class Household_ToiletBrushSet
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("25c4ff90-79e6-4d88-bda6-cce18f8cb5a0");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Silicone Toilet Brush & Holder",
            Code = "HOU-002",
            Price = 19.99m,
            Quantity = 100,
            CategoryId = Guid.Parse("2f4f0438-f456-4770-9d49-1a46ed4ec88a"),
            ImageUrls = [
                "https://m.media-amazon.com/images/I/31lXMBFhMpL._SX522_.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute { Id = Guid.Parse("949da2bb-18d8-4b1c-8e8d-2f10f011d5f7"), ProductId = productId, Key = "Material", Value = "Silicone + Plastic" },
            new ProductAttribute { Id = Guid.Parse("87a5f690-bcb1-4c00-a649-cb40f907e6f3"), ProductId = productId, Key = "Color", Value = "White/Grey" },
            new ProductAttribute { Id = Guid.Parse("27449383-41e3-45f2-84d4-df3d02ec949b"), ProductId = productId, Key = "Type", Value = "Wall-mounted" },
            new ProductAttribute { Id = Guid.Parse("d22b2c79-63f2-4c5f-888c-12d569df4455"), ProductId = productId, Key = "Replaceable Head", Value = "Yes" }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature { Id = Guid.Parse("19738491-3030-4b3b-9819-353117c4fc5e"), ProductId = productId, Name = "Hygiene", Description = "Quick-drying ventilation base" },
            new ProductFeature { Id = Guid.Parse("4a1174ed-faf9-41de-9769-98a7c31560ef"), ProductId = productId, Name = "Durability", Description = "Flexible anti-scratch bristles" },
            new ProductFeature { Id = Guid.Parse("a40b5a25-8d40-47d5-b509-cf01d6cb44f6"), ProductId = productId, Name = "Convenience", Description = "No-drill installation" },
            new ProductFeature { Id = Guid.Parse("b8b470f9-3720-4a95-918b-02f6ddbb0f5d"), ProductId = productId, Name = "Eco-Friendly", Description = "Reusable & replaceable head" }
        );
    }
}