using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Household;

public static class Household_LaundryBasket
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("8888aaaa-bbbb-cccc-dddd-eeee00000003");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Collapsible Laundry Basket",
            Code = "HOU-003",
            Price = 19.99m,
            Quantity = 100,
            CategoryId = Guid.Parse("6fa8707d-97d7-41a1-9c31-50f07b8466f4"),
            ImageUrls =
            [
                "https://content2.rozetka.com.ua/goods/images/big/378171578.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/378171579.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/378171580.jpg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000301"), ProductId = productId, Key = "Material",
                Value = "Polyester"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000302"), ProductId = productId, Key = "Capacity",
                Value = "60L"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000303"), ProductId = productId, Key = "Foldable",
                Value = "Yes"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000304"), ProductId = productId, Key = "Weight",
                Value = "0.5kg"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000401"), ProductId = productId, Name = "Handles",
                Description = "Reinforced carry handles for easy transport"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000402"), ProductId = productId, Name = "Design",
                Description = "Breathable mesh sides"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000403"), ProductId = productId, Name = "Storage",
                Description = "Compact foldable design"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000404"), ProductId = productId, Name = "Use",
                Description = "Ideal for dorms, apartments, or travel"
            }
        );
    }
}