using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data;

public static class SeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var categoryId = new Guid("11111111-1111-1111-1111-111111111111");
        var detailsId = new Guid("33333333-3333-3333-3333-333333333333");
        var productId = new Guid("22222222-2222-2222-2222-222222222222");

        modelBuilder.Entity<Category>().HasData(new Category
        {
            Id = categoryId,
            Name = "Books"
        });

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

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = productId,
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
