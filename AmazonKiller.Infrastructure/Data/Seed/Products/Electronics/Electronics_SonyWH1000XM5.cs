using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_SonyWH1000XM5
{
    public static void Seed(ModelBuilder modelBuilder)
    {
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
                "https://content2.rozetka.com.ua/goods/images/big/296707484.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/296707485.jpg"
            ]
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