using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Fashion;

public static class Fashion_MensLeatherJacket
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777ffff-aaaa-bbbb-cccc-dddd00000002");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Men's Genuine Leather Jacket",
            Code = "FAS-006",
            Price = 179.99m,
            Quantity = 20,
            CategoryId = Guid.Parse("7eb489f4-2f55-4510-8e49-3965370c4989"),
            ImageUrls =
            [
                "https://content2.rozetka.com.ua/goods/images/big/331352901.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/331352912.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/331352917.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000161"), ProductId = productId, Key = "Material", Value = "Genuine Leather" },
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000162"), ProductId = productId, Key = "Color", Value = "Black" },
            new ProductAttribute { Id = Guid.Parse("00000000-0000-0000-0000-000000000163"), ProductId = productId, Key = "Size", Value = "M-XXL" }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature { Id = Guid.Parse("00000000-0000-0000-0000-000000000261"), ProductId = productId, Name = "Style", Description = "Classic biker look with zipper closure" },
            new ProductFeature { Id = Guid.Parse("00000000-0000-0000-0000-000000000262"), ProductId = productId, Name = "Warmth", Description = "Fully lined for winter use" }
        );
    }
}