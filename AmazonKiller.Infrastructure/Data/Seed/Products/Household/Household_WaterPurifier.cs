using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Household;

public static class Household_WaterPurifier
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777eeee-aaaa-bbbb-cccc-dddd00000004");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "AquaPro RO+UV+UF Water Purifier",
            Code = "HOU-007",
            Price = 199.99m,
            Quantity = 45,
            CategoryId = Guid.Parse("8980e70c-3345-4885-8518-cfcda95b3078"),
            ImageUrls =
            [
                "https://ecosoft.ua/upload/resize_cache/iblock/d40/564_564_140cd750bba9870f18aada2478b24840a/ru_filtr_obratnogo_osmosa_ecosoft_standard_pro_mo550mecostd_ua_filtr_zvorotnogo_osmosu_ecosoft_stand.webp",
                "https://ecosoft.ua/upload/resize_cache/iblock/527/564_564_140cd750bba9870f18aada2478b24840a/mo550ecostd_1_opt.webp",
                "https://ecosoft.ua/upload/resize_cache/iblock/391/564_564_140cd750bba9870f18aada2478b24840a/mo550ecostd_4_opt.webp"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000191"), ProductId = productId, Key = "Technology",
                Value = "RO+UV+UF"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000192"), ProductId = productId,
                Key = "Storage Capacity", Value = "8 Liters"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000193"), ProductId = productId, Key = "Power",
                Value = "36W"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000291"), ProductId = productId, Name = "Purification",
                Description = "Removes bacteria, viruses, and TDS"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000292"), ProductId = productId, Name = "Design",
                Description = "Wall-mounted with transparent cover"
            }
        );
    }
}