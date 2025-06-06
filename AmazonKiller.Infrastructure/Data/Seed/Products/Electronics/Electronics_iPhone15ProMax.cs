using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_IPhone15ProMax
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("ea96f23c-13b2-4b2c-b4a6-ec7d8c19aef5");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Apple iPhone 15 Pro Max",
            Code = "APP-002",
            Price = 1399.99m,
            Quantity = 40,
            CategoryId = Guid.Parse("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
            ImageUrls =
            [
                "https://content2.rozetka.com.ua/goods/images/big/524114081.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/524114107.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/524114117.jpg",
                "https://content2.rozetka.com.ua/goods/images/big/524114126.jpg",
                "https://content1.rozetka.com.ua/goods/images/big/524114144.jpg"
            ],
            Rating = 4.7m,
            ReviewsCount = 200
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("b5bdf51b-e460-4e8a-8c44-22625f91ae45"), ProductId = productId, Key = "Display",
                Value = "6.7-inch OLED"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("3b15cf2c-d0a6-45bb-a99f-2f0fa66cf91c"), ProductId = productId, Key = "Chip",
                Value = "A17 Pro"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("a49880a3-4ba6-4bb0-8015-4bc83b6dbbcd"), ProductId = productId, Key = "Camera",
                Value = "48MP Triple-lens"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("83cfd9cb-24a9-4056-bb90-85986b3b6310"), ProductId = productId, Key = "Storage",
                Value = "256GB"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("56e75d3f-9fb5-4d8c-a986-8985a8aa96c1"), ProductId = productId, Name = "Build Quality",
                Description = "Titanium frame"
            },
            new ProductFeature
            {
                Id = Guid.Parse("76bdc733-91d3-48f1-a447-b78e0e4b9991"), ProductId = productId, Name = "Performance",
                Description = "Smooth iOS experience"
            },
            new ProductFeature
            {
                Id = Guid.Parse("06695e1f-8d42-498c-8d34-e3281d49753b"), ProductId = productId, Name = "Camera System",
                Description = "Cinematic mode & Night photography"
            },
            new ProductFeature
            {
                Id = Guid.Parse("e4c01f56-8e2e-4866-a98f-6c4f69f63f6f"), ProductId = productId, Name = "Battery Life",
                Description = "Up to 29 hours video playback"
            }
        );
    }
}