using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Furniture;

public static class Furniture_WoodenBookshelf
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777dddd-aaaa-bbbb-cccc-eeee00000003");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Solid Wood Bookshelf 5-Tier",
            Code = "FUR-006",
            Price = 129.99m,
            Quantity = 30,
            CategoryId = Guid.Parse("c9f81657-73a1-4b53-bf80-b59121eae433"),
            ImageUrls =
            [
                "https://cdn1.jysk.com/getimage/wd3.large/245914",
                "https://cdn1.jysk.com/getimage/wd3.large/245910",
                "https://cdn1.jysk.com/getimage/wd3.large/161839",
                "https://cdn1.jysk.com/getimage/wd3.large/161840"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000181"), ProductId = productId, Key = "Material",
                Value = "Pine Wood"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000182"), ProductId = productId, Key = "Color",
                Value = "Walnut Brown"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000183"), ProductId = productId, Key = "Shelves",
                Value = "5"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000281"), ProductId = productId, Name = "Durability",
                Description = "Supports up to 30kg per shelf"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000282"), ProductId = productId, Name = "Style",
                Description = "Rustic farmhouse design"
            }
        );
    }
}