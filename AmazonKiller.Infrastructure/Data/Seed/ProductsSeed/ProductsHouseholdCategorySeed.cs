using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.ProductsSeed;

public static class ProductsHouseholdCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Name = "Dyson V15 Detect Vacuum Cleaner",
            Code = "HOU-001",
            Price = 699.0m,
            Quantity = 50,
            CategoryId = new Guid("8980e70c-3345-4885-8518-cfcda95b3078"),
            ImageUrls =
            [
                "https://example.com/products/dyson1.jpg",
                "https://example.com/products/dyson2.jpg"
            ],
            Rating = 4.5m,
            ReviewsCount = 100
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("5a29ac69-487d-4609-b29e-3b6f30b088ce"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Key = "Type",
            Value = "Cordless"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("7ba0bf0e-ed40-4e27-a0ac-85dd45279867"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Key = "Battery Life",
            Value = "60 minutes"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("7c252a25-5c76-4e8b-be65-22e8651667ed"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Key = "Dustbin Capacity",
            Value = "0.76L"
        });
        modelBuilder.Entity<ProductAttribute>().HasData(new ProductAttribute
        {
            Id = new Guid("b559db54-4289-499f-88dc-35a4c9978e4c"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Key = "Power",
            Value = "230AW"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("75e0cc52-9a6b-4157-b453-57f390790cf4"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Name = "Performance",
            Description = "Laser detects microscopic dust"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("1822758b-de5a-4f53-aea5-c624d90add9b"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Name = "Efficiency",
            Description = "Intelligent optimization"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("9b6befa0-ebf3-4701-a70c-a8bb3c8689a1"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Name = "Filter",
            Description = "Whole-machine HEPA filtration"
        });
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = new Guid("7c49174a-ea92-4119-b3bb-2951ffbaba67"),
            ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
            Name = "Tools",
            Description = "Multiple attachments included"
        });
    }
}