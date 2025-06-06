using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.WorkTools;

public static class WorkTools_PortableDrill
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777ffff-aaaa-bbbb-cccc-dddd00000005");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Bosch GSB 180-LI Cordless Drill",
            Code = "TOOL-010",
            Price = 139.99m,
            Quantity = 60,
            CategoryId = Guid.Parse("834ba378-fe57-4702-b85c-4cb0431d1909"),
            ImageUrls =
            [
                "https://content1.rozetka.com.ua/goods/images/big/318774509.jpg",
                "https://content.rozetka.com.ua/goods/images/big/318774562.png",
                "https://content2.rozetka.com.ua/goods/images/big/318774588.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000261"), ProductId = productId, Key = "Type",
                Value = "Cordless Drill"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000262"), ProductId = productId, Key = "Battery",
                Value = "18V Li-ion"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000263"), ProductId = productId, Key = "Max Torque",
                Value = "54 Nm"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000361"), ProductId = productId, Name = "Speed",
                Description = "2-speed gearbox for optimized performance"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000362"), ProductId = productId, Name = "Durability",
                Description = "Robust housing and overload protection"
            }
        );
    }
}