using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products;

public static class ProductsWorkToolsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Name = "Makita Cordless Hammer Drill",
            Code = "WTL-001",
            Price = 229.99m,
            Quantity = 50,
            CategoryId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
            ImageUrls =
            [
                "https://example.com/products/makita1.jpg",
                "https://example.com/products/makita2.jpg"
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("e0e1e5c9-55d8-4d16-bca2-e45a0d3553cc"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Key = "Voltage",
            Value = "18V"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("90bba9ca-cc95-405e-8a8e-da471eafcde2"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Key = "Chuck Size",
            Value = "13mm"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("f46c7e06-8dfe-48e9-b47e-9953e159ae69"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Key = "Speed",
            Value = "0-2000 RPM"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("07d62dcb-0736-4687-b066-92c3cde5fa9d"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Key = "Battery",
            Value = "2 x 5.0Ah Li-ion"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("49b29ac4-ed20-4592-8690-304aa1e80df3"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Name = "Performance",
            Description = "High torque for tough jobs"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("8166c8f2-21fd-439c-ad3f-1eabe29bc76f"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Name = "Comfort",
            Description = "Ergonomic grip"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("c4c5a991-e2cd-4d1b-a176-036f70667cb7"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Name = "LED Light",
            Description = "For dark areas"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("a3c061b9-91f9-4d01-be37-4eb05da33ac5"),
            ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
            Name = "Durability",
            Description = "Metal gear housing"
        });
    }
}