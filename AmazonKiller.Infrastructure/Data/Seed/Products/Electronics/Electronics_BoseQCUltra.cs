using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_BoseQCUltra
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("12a5f27a-59d1-4961-86d7-14a787f8eec8");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Bose QuietComfort Ultra",
            Code = "BOSE-001",
            Price = 379.99m,
            Quantity = 35,
            CategoryId = Guid.Parse("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
            ImageUrls =
            [
                "https://content2.rozetka.com.ua/goods/images/big/382915623.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/382915624.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/382915625.jpg",
                "https://content.rozetka.com.ua/goods/images/big/382915629.jpg",
            ],
            Rating = 4.6m,
            ReviewsCount = 150
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("aa64df41-c001-4d1a-91b7-0807f2b5c0de"), ProductId = productId, Key = "Type",
                Value = "Over-ear"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("44c10d0d-414c-4a75-baff-b5246a6e688b"), ProductId = productId,
                Key = "Noise Cancellation", Value = "Adaptive"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("6fa61d21-700f-4c0e-a04f-c1a1a8a2745b"), ProductId = productId, Key = "Battery Life",
                Value = "24 hours"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("75c1376d-1ae0-405f-a46d-15c805e3e212"), ProductId = productId, Key = "Charging",
                Value = "USB-C Fast Charging"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("f00725dc-2d23-4ff3-93b6-bcb9fdf8f293"), ProductId = productId, Name = "Sound Quality",
                Description = "CustomTune technology"
            },
            new ProductFeature
            {
                Id = Guid.Parse("2e5c6e3a-bb5f-42f7-b933-0e21dcdb267f"), ProductId = productId, Name = "Comfort",
                Description = "Plush cushioning"
            },
            new ProductFeature
            {
                Id = Guid.Parse("93c3210e-48e6-4fc4-8783-47bdc8601694"), ProductId = productId, Name = "Controls",
                Description = "Touch & voice control"
            },
            new ProductFeature
            {
                Id = Guid.Parse("da2c2ff2-1c38-4a23-a8cc-25b4f4ec2680"), ProductId = productId, Name = "Design",
                Description = "Modern aesthetic"
            }
        );
    }
}