// AmazonKiller.Infrastructure/Data/SeedData.cs

using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // ---- заранее сгенерированные статические GUID’ы -----------
        var categoryId = new Guid("11111111-1111-1111-1111-111111111111");
        var detailsId = new Guid("33333333-3333-3333-3333-333333333333");
        var productId = new Guid("22222222-2222-2222-2222-222222222222");

        // ——— фиксированное (!) значение ULID ———
        //  любое валидное 26‑символьное значение, лишь бы оно не менялось.
        const string productCode = "01JS9QNDAYKK2CFRT5AKZF1YAA";

        // ----------- Category -----------
        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = categoryId,
            Name = "Books"
        });

        // ----------- ProductDetails -----------
        modelBuilder.Entity<ProductDetails>().HasData(new ProductDetails
        {
            Id = detailsId,
            FabricType = "Paper",
            CareInstructions = "Keep dry",
            Origin = "USA",
            ClosureType = "None",
            Brand = Brands.ASOS,
            Color = Colors.White,
            ClothesSize = null,
            ShoesSize = null
        });

        // ----------- Products -----------
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
            Code = productCode, // ← больше НЕ генерируется на лету
            Name = "C# in Depth",
            Price = 39.99m,
            ReviewsCount = 0,
            Quantity = 10,
            Status = ProductStatus.InStock,
            Rating = Rating.Five,
            CategoryId = categoryId,
            InWishlist = false,
            InCartList = false,
            DetailsId = detailsId
        });
    }
}