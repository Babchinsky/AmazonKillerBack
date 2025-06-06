using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_LenovoLaptop
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("82d2d24a-1dc5-491b-926d-b4e72d168115");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Lenovo ThinkPad X1 Carbon Gen 11",
            Code = "ELE-003",
            Price = 1899.99m,
            Quantity = 25,
            CategoryId = Guid.Parse("22e7ee0d-8962-482b-857d-43ba828de1ff"),
            ImageUrls = [
                "https://content2.rozetka.com.ua/goods/images/big/423031985.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/423031986.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/423031987.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/423031988.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/423031989.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute { Id = Guid.Parse("adcccfb2-5f3b-44d2-b3bc-0091e084d27f"), ProductId = productId, Key = "Display", Value = "14\" FHD+ IPS" },
            new ProductAttribute { Id = Guid.Parse("50983ef4-7586-4be1-a6c7-eac4c7fd90a7"), ProductId = productId, Key = "CPU", Value = "Intel Core i7-1355U" },
            new ProductAttribute { Id = Guid.Parse("b390fa02-66b0-4d7b-8f2c-046cd0c93187"), ProductId = productId, Key = "RAM", Value = "16GB LPDDR5" },
            new ProductAttribute { Id = Guid.Parse("be3a6d15-cb6b-490a-87f1-6a54bd1614ec"), ProductId = productId, Key = "Storage", Value = "512GB SSD" }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature { Id = Guid.Parse("aeef3fa9-5e61-4bb8-8bff-2b5884c32596"), ProductId = productId, Name = "Portability", Description = "Ultra-light carbon fiber body" },
            new ProductFeature { Id = Guid.Parse("960b60da-6796-46ce-bb6f-6cc84ef70f1f"), ProductId = productId, Name = "Keyboard", Description = "Legendary ThinkPad tactile typing" },
            new ProductFeature { Id = Guid.Parse("d891dc16-0e25-4412-b43f-e5f5e2450a70"), ProductId = productId, Name = "Security", Description = "Fingerprint + IR camera" },
            new ProductFeature { Id = Guid.Parse("9c7ad3cf-06f1-4a96-844f-f7c6ae5e0249"), ProductId = productId, Name = "Battery", Description = "15+ hour runtime" }
        );
    }
}