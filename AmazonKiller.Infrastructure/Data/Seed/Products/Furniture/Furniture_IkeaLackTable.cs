using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;

public static class Furniture_IkeaLackTable
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("b7a6497f-c4cb-4d7c-afe5-167c02cbf170");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "IKEA LACK Coffee Table",
            Code = "FUR-002",
            Price = 39.99m,
            Quantity = 80,
            CategoryId = Guid.Parse("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"),
            ImageUrls =
            [
                "https://home-club.com.ua//images/thumbs/0018524_-_510.jpeg",
                "https://home-club.com.ua//images/thumbs/0310065_-.jpeg",
                "https://home-club.com.ua//images/thumbs/0043920_-.jpeg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("c8d6d4e7-3c25-41f4-9c3c-144143d3cb94"), ProductId = productId, Key = "Material",
                Value = "Particleboard"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("ec9f4ff8-dc66-4a6a-a88d-dfd03275e05a"), ProductId = productId, Key = "Dimensions",
                Value = "90x55 cm"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("e0701d10-c221-4032-b3a5-4a05c69f56c5"), ProductId = productId, Key = "Weight",
                Value = "5.8kg"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("7aa17ee1-6b46-4d41-8ae2-4f2f2931e0aa"), ProductId = productId, Key = "Finish",
                Value = "White"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("431d02bb-1446-4d9a-8f71-207b6d0ffbe1"), ProductId = productId, Name = "Design",
                Description = "Simple and modern"
            },
            new ProductFeature
            {
                Id = Guid.Parse("146e8860-5f1a-4086-85a1-bcbe5e16a982"), ProductId = productId, Name = "Assembly",
                Description = "Tool-free assembly"
            },
            new ProductFeature
            {
                Id = Guid.Parse("a3a37d1e-26e9-40f0-b935-1e5e43b83e02"), ProductId = productId, Name = "Affordability",
                Description = "Budget-friendly option"
            },
            new ProductFeature
            {
                Id = Guid.Parse("a90fa301-e8e3-4097-a507-cdc1a9f5b008"), ProductId = productId, Name = "Portability",
                Description = "Lightweight design"
            }
        );
    }
}