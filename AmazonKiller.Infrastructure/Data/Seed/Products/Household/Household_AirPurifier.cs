using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Household;

public static class Household_AirPurifier
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777eeee-aaaa-bbbb-cccc-dddd00000006");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Philips Series 3000i Air Purifier",
            Code = "HOU-006",
            Price = 319.00m,
            Quantity = 35,
            CategoryId = Guid.Parse("8980e70c-3345-4885-8518-cfcda95b3078"),
            ImageUrls =
            [
                "https://content.rozetka.com.ua/goods/images/big/529433930.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/469768391.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000481"), ProductId = productId, Key = "Coverage Area",
                Value = "104 m²"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000482"), ProductId = productId, Key = "CADR",
                Value = "400 m³/h"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000483"), ProductId = productId, Key = "Filter Type",
                Value = "HEPA + Carbon"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000481"), ProductId = productId, Name = "Smart Features",
                Description = "App control and air quality feedback"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000482"), ProductId = productId, Name = "Silent Mode",
                Description = "Operates as low as 33 dB"
            }
        );
    }
}