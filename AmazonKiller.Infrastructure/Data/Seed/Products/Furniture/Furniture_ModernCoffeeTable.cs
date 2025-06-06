using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;

public static class Furniture_ModernCoffeeTable
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Name = "Modern Wooden Coffee Table",
            Code = "FUR-001",
            Price = 149.99m,
            Quantity = 50,
            CategoryId = new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"),
            ImageUrls =
            [
                "https://cdn2.jysk.com/getimage/wd3.medium/256592",
                "https://cdn2.jysk.com/getimage/wd3.medium/254304"
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("a6a26067-18e9-4543-8828-8069f09a411f"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Key = "Material",
            Value = "Oak wood"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("50c7325d-5a50-4494-8356-c4ae304e70f5"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Key = "Dimensions",
            Value = "120x60x45 cm"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("163febea-12c5-4ba7-af3e-5b3d5fa01e4f"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Key = "Weight",
            Value = "18kg"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("4946c132-8ec4-41ce-891d-4788067a4a66"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Key = "Finish",
            Value = "Natural varnish"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("35198d10-7fbf-4919-aa3f-527c7e76abcb"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Name = "Design",
            Description = "Sleek and minimal"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("6334b668-3933-4abb-8d5d-4324bb4ed08a"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Name = "Durability",
            Description = "Solid wood construction"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("b6e56093-2fc5-473d-818a-26a9e5b52f82"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Name = "Maintenance",
            Description = "Easy to wipe clean"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("f4eb7825-2ffd-4d1f-a9ba-5635ea698534"),
            ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
            Name = "Assembly",
            Description = "Quick setup included"
        });
    }
}