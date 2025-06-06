using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Fashion;

public static class Fashion_WomensHat
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777bbbb-cccc-dddd-eeee-ffff00000001");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Stylish Women's Summer Hat",
            Code = "FAS-005",
            Price = 34.99m,
            Quantity = 40,
            CategoryId = Guid.Parse("69f22c76-7202-44e6-9132-09fd09c55632"),
            ImageUrls =
            [
                "https://img.kwcdn.com/product/open/17a385505e6240aaa133bfb681d557a5-goods.jpeg?imageView2/2/w/800/q/70/format/webp",
                "https://img.kwcdn.com/product/open/61685065fd0e459d9af558fcf949ee83-goods.jpeg?imageView2/2/w/800/q/70/format/webp"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000331"), ProductId = productId, Key = "Material",
                Value = "Straw"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000332"), ProductId = productId, Key = "Color",
                Value = "Beige"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000333"), ProductId = productId, Key = "Size",
                Value = "One Size Fits Most"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000431"), ProductId = productId, Name = "Sun Protection",
                Description = "Wide brim blocks UV rays"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000432"), ProductId = productId, Name = "Design",
                Description = "Breathable and lightweight"
            }
        );
    }
}