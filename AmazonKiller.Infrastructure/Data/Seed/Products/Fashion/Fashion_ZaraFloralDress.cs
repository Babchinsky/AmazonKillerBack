using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Fashion;

public static class Fashion_ZaraFloralDress
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("6f4c984f-7baf-4a39-aab3-018202f20de5");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Zara Floral Midi Dress",
            Code = "FAS-002",
            Price = 89.99m,
            Quantity = 70,
            CategoryId = Guid.Parse("69f22c76-7202-44e6-9132-09fd09c55632"),
            ImageUrls =
            [
                "https://static.zara.net/assets/public/5383/1e3a/567f4efa9ab2/540875121096/04772368808-p/04772368808-p.jpg?ts=1747906901087&w=750",
                "https://static.zara.net/assets/public/1739/0738/387f4ed59035/81ddaea8d349/04772368808-a2/04772368808-a2.jpg?ts=1747906905715&w=750",
                "https://static.zara.net/assets/public/6eda/d9b8/33b748b0941d/85074a50ec93/04772368808-a4/04772368808-a4.jpg?ts=1747906897381&w=563"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("c1f7efb2-8dbb-4d6e-890b-91873cc0f8a2"), ProductId = productId, Key = "Material",
                Value = "Viscose"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("184d5fd1-4e1d-42c2-9b58-d5d3c1b2235a"), ProductId = productId, Key = "Fit",
                Value = "Relaxed"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("3a57dbde-0659-4377-a618-5477c3f1c6ae"), ProductId = productId, Key = "Length",
                Value = "Midi"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("3d768f6d-11d5-4033-8b6e-c2674d37b44a"), ProductId = productId, Key = "Pattern",
                Value = "Floral"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("b9b205bb-9a76-4456-a0cb-dc28e4fce1c5"), ProductId = productId, Name = "Style",
                Description = "Elegant and breezy"
            },
            new ProductFeature
            {
                Id = Guid.Parse("781153a3-0555-49ae-987e-09dbde5172ee"), ProductId = productId, Name = "Versatility",
                Description = "Suitable for casual and formal"
            },
            new ProductFeature
            {
                Id = Guid.Parse("a5fd738e-6d61-49f7-b51c-dcdbbcd27644"), ProductId = productId, Name = "Comfort",
                Description = "Breathable fabric"
            },
            new ProductFeature
            {
                Id = Guid.Parse("fbf426f5-78e4-4d4f-b183-3fcf3870e04b"), ProductId = productId, Name = "Care",
                Description = "Machine washable"
            }
        );
    }
}