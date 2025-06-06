using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Electronics;

public static class Electronics_SamsungTV
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("7777eeee-ffff-aaaa-bbbb-cccc00000001");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Samsung QLED 4K Smart TV 55\"",
            Code = "ELE-006",
            Price = 1099.99m,
            Quantity = 15,
            CategoryId = Guid.Parse("8fc8707d-97d7-41a1-9c31-50f07b8466f4"),
            ImageUrls =
            [
                "https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-544778064?$684_547_JPG$",
                "https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-541007467?$684_547_JPG$",
                "https://images.samsung.com/is/image/samsung/p6pim/ua/qe55s95dauxua/gallery/ua-oled-s95d-qe55s95dauxua-544308036?$684_547_JPG$"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000151"), ProductId = productId, Key = "Screen Size",
                Value = "55 inch"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000152"), ProductId = productId, Key = "Resolution",
                Value = "4K Ultra HD"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000153"), ProductId = productId, Key = "Display Type",
                Value = "QLED"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000154"), ProductId = productId, Key = "Smart TV",
                Value = "Yes"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000251"), ProductId = productId, Name = "Voice Control",
                Description = "Supports Bixby, Alexa, and Google Assistant"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000252"), ProductId = productId, Name = "HDR",
                Description = "Quantum HDR with deep contrast"
            },
            new ProductFeature
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000253"), ProductId = productId, Name = "Design",
                Description = "Slim look with almost no bezel"
            }
        );
    }
}