using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.ProductsSeed;

public static class ProductsFashionCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product {
            Id = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Name = "Men's Denim Jacket",
            Code = "FAS-001",
            Price = 69.99m,
            Quantity = 50,
            CategoryId = new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"),
            ImageUrls = [
                "https://example.com/products/jacket1.jpg",
                "https://example.com/products/jacket2.jpg",
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute {
            Id = new Guid("f75be0e7-0d41-45e8-87d7-e53060c87cd4"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Key = "Material",
            Value = "100% Cotton"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute {
            Id = new Guid("34b80662-4ddf-44df-aeab-0a131d4ca441"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Key = "Fit",
            Value = "Regular"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute {
            Id = new Guid("93731c22-16a2-4c9e-b4d8-3aa7485d5acb"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Key = "Color",
            Value = "Blue"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute {
            Id = new Guid("ac51bf93-88a8-4b39-b106-b8a7f5c4db92"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Key = "Season",
            Value = "All seasons"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature {
            Id = new Guid("f7f4c40c-82d3-488f-bf1a-9094dc2048b0"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Name = "Style",
            Description = "Casual yet rugged"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature {
            Id = new Guid("905cdea9-9662-4f42-82d4-c0b24e957ee8"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Name = "Versatility",
            Description = "Pairs with any outfit"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature {
            Id = new Guid("38c8f67f-7b05-4f06-8856-546a4e499d5c"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Name = "Durability",
            Description = "Made to last"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature {
            Id = new Guid("7aeefca5-b681-41cf-baef-0ab5306f250a"),
            ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
            Name = "Care",
            Description = "Machine washable"
        });
    }
}