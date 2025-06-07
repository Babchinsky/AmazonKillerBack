using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.WorkTools;

public static class WorkTools_SafetyHelmet
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("8888aaaa-bbbb-cccc-dddd-eeee00000005");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "3M Safety Helmet H-700 Series",
            Code = "TOOL-005",
            Price = 35.99m,
            Quantity = 150,
            CategoryId = Guid.Parse("18710447-a260-44f2-9a4b-77c0b246bbc5"),
            ImageUrls =
            [
                "https://biko.ua/image/cache/catalog/product/19139/195700-500x500.jpg",
                "https://biko.ua/image/cache/catalog/product/19139/5bbab5-500x500.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000141"), ProductId = productId, Key = "Material",
                Value = "High-Density Polyethylene"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000142"), ProductId = productId, Key = "Suspension",
                Value = "4-point ratchet"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000143"), ProductId = productId, Key = "Ventilation",
                Value = "Yes"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000144"), ProductId = productId, Key = "Standard",
                Value = "ANSI/ISEA Z89.1-2014"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000241"), ProductId = productId, Name = "Comfort",
                Description = "Soft brow pad and adjustable fit"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000242"), ProductId = productId, Name = "Durability",
                Description = "Impact-resistant outer shell"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000243"), ProductId = productId, Name = "Compatibility",
                Description = "Accessory slots for face shields and earmuffs"
            }
        );
    }
}