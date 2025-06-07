using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_SonyCamera
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777aaaa-bbbb-cccc-dddd-eeee00000001");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Sony Alpha a6400 Mirrorless Camera",
            Code = "ELE-005",
            Price = 899.99m,
            Quantity = 25,
            CategoryId = Guid.Parse("8fc8707d-97d7-41a1-9c31-50f07b8466f4"),
            ImageUrls =
            [
                "https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/2/000202052_1054_1054.jpeg",
                "https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/3/000202053_1054_1054.jpeg",
                "https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/4/000202054_1054_1054.jpeg",
                "https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/5/000202055_1054_1054.jpeg",
                "https://cdn.tehnoezh.ua/0/0/0/2/0/2/0/5/6/000202056_1054_1054.jpeg"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000101"), ProductId = productId, Key = "Resolution",
                Value = "24.2MP"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000102"), ProductId = productId, Key = "Sensor",
                Value = "APS-C CMOS"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000103"), ProductId = productId, Key = "Video",
                Value = "4K UHD"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000104"), ProductId = productId, Key = "Lens Mount",
                Value = "Sony E-mount"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000201"), ProductId = productId, Name = "Autofocus",
                Description = "425 phase-detection points"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000202"), ProductId = productId, Name = "Screen",
                Description = "180° tiltable LCD"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000203"), ProductId = productId, Name = "Connectivity",
                Description = "Wi-Fi, NFC, Bluetooth"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000204"), ProductId = productId, Name = "Build",
                Description = "Magnesium alloy body"
            }
        );
    }
}