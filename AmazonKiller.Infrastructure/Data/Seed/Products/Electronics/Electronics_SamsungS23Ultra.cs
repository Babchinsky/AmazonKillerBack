using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_SamsungS23Ultra
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
                "https://content.rozetka.com.ua/goods/images/big/398092199.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/398092200.jpg",
                "https://content.rozetka.com.ua/goods/images/big/398092201.jpg",
                "https://content.rozetka.com.ua/goods/images/big/398092202.jpg",
                "https://content.rozetka.com.ua/goods/images/big/398092203.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/398092204.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/398092205.jpg",
                "https://content.rozetka.com.ua/goods/images/big/398092206.jpg"
            ]
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
    }
}