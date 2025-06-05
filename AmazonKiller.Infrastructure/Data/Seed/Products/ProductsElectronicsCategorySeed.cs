using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products;

public static class ProductsElectronicsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Name = "Samsung Galaxy S23 Ultra",
            Code = "SAM-001",
            Price = 1199.99m,
            Quantity = 50,
            CategoryId = new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
            ImageUrls =
            [
                "https://example.com/products/samsung1.jpg",
                "https://example.com/products/samsung2.jpg"
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("31ed2059-8d7c-440e-849c-92b82fa07535"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Key = "Display",
            Value = "6.8-inch AMOLED"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("5d1af968-e023-4bf1-a58b-4d6701785946"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Key = "Battery",
            Value = "5000mAh"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("2d3c46bc-1bd0-45c0-a695-6b3ea0cea55d"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Key = "Camera",
            Value = "200MP"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("45890b2d-4656-4bf5-bea8-8d68cef13afa"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Key = "Storage",
            Value = "256GB"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("c6676eab-a776-4380-9b0e-a07b10da8236"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Name = "Performance",
            Description = "Snapdragon 8 Gen 2"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("9f7ba4ac-9b83-41bc-9fc9-53896c0fcd17"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Name = "Camera Quality",
            Description = "Pro-grade camera system"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("1e8754f1-993e-4586-b0df-d16475bcd262"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Name = "Battery Life",
            Description = "All-day usage"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("015d3ed7-c231-405e-bbd2-ef99c8171603"),
            ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
            Name = "Build",
            Description = "Premium glass and metal"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Name = "Sony WH-1000XM5 Headphones",
            Code = "SONY-002",
            Price = 349.99m,
            Quantity = 50,
            CategoryId = new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
            ImageUrls =
            [
                "https://example.com/products/sony1.jpg",
                "https://example.com/products/sony2.jpg"
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("eb86dc2a-68a2-4f38-a498-4d21a2dfd366"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Key = "Type",
            Value = "Over-ear"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("bdb82599-d1ed-4257-8429-0c5bf8ba3094"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Key = "Noise Cancellation",
            Value = "Yes"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("8f9b1a9b-6472-4251-b3b9-0dc488ac3ca3"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Key = "Battery Life",
            Value = "30 hours"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("1940fec2-48f2-40ab-a4a0-199adcce9e52"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Key = "Connectivity",
            Value = "Bluetooth 5.2"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("7833296c-251c-4868-9bc2-3da59b3cd811"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Name = "Sound",
            Description = "High-resolution audio"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("b6634cd8-0a8c-4ada-b8cc-310b490c6058"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Name = "Comfort",
            Description = "Soft ear cushions"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("542a9d5b-af5f-4709-82b1-ed83b2d9143d"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Name = "Controls",
            Description = "Touch-enabled"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("edb89e51-144c-48a7-8fbf-7a645abc970b"),
            ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
            Name = "Portability",
            Description = "Foldable design"
        });
    }
}