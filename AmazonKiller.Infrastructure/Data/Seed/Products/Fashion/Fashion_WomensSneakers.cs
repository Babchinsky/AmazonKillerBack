using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Products.Fashion;

public static class Fashion_WomensSneakers
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var productId = Guid.Parse("c26e813d-2f01-4d0b-8d3c-209fbe35b7c2");

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Name = "Nike Air Max 270 Women’s",
            Code = "FAS-003",
            Price = 129.99m,
            Quantity = 60,
            CategoryId = Guid.Parse("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"),
            ImageUrls =
            [
                "https://img.modivo.cloud/product(5/4/5/9/54595f77bbbe0dda2ded1c7a961e279ff9bd34a7_0000207922853_01_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp",
                "https://img.modivo.cloud/product(1/f/8/9/1f89d5521273cfa7afca6e03500f99cb54bb9501_0000207922853_03_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp",
                "https://img.modivo.cloud/product(6/d/0/0/6d009576160e83813798096c877e9b7ee1b329a5_0000207922853_02_jb_kopia.jpg,webp)/nike-vzuttia-air-max-270-ah6789-100-bilii.webp"
            ]
        });

        modelBuilder.Entity<ProductAttribute>().HasData(
            new ProductAttribute
            {
                Id = Guid.Parse("ca0c370e-e27d-4ec6-89b2-1ed26b3db5c3"), ProductId = productId, Key = "Size",
                Value = "US 6–10"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("1cf8cf59-8f36-4f7c-b332-97c68a4692c0"), ProductId = productId, Key = "Color",
                Value = "White/Pink"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("7b7ec203-7f23-47ae-80d1-20b7f936a160"), ProductId = productId, Key = "Upper",
                Value = "Mesh + Synthetic"
            },
            new ProductAttribute
            {
                Id = Guid.Parse("c2d1f858-b56c-487f-9a71-c04d6cba91e3"), ProductId = productId, Key = "Outsole",
                Value = "Rubber"
            }
        );

        modelBuilder.Entity<ProductFeature>().HasData(
            new ProductFeature
            {
                Id = Guid.Parse("0072b22f-4b44-4c2b-8fe9-996e1b0aa832"), ProductId = productId, Name = "Cushioning",
                Description = "Visible Air Max unit"
            },
            new ProductFeature
            {
                Id = Guid.Parse("2bda4a7f-cd79-47b1-94bb-d237e52794ae"), ProductId = productId, Name = "Design",
                Description = "Sporty & stylish"
            },
            new ProductFeature
            {
                Id = Guid.Parse("8412c1ff-2650-42e3-844b-9a1c36522aa4"), ProductId = productId, Name = "Comfort",
                Description = "Foam midsole"
            },
            new ProductFeature
            {
                Id = Guid.Parse("71f2be1d-44a1-4216-96c5-589cba78d144"), ProductId = productId, Name = "Breathability",
                Description = "Perforated upper"
            }
        );
    }
}