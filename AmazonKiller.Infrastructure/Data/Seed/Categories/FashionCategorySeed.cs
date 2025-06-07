using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class FashionCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var rootId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Fashion",
                Status = CategoryStatus.Active,
                Description = "Fashion category",
                ImageUrl = "https://theplanetapp.com/wp-content/uploads/2022/08/fast-fashion-1-scaled-1-scaled.webp",
                IconName = "hanger"
            },
            new Category
            {
                Id = new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"),
                Name = "Men's Clothing",
                Status = CategoryStatus.Active,
                Description = "Men's Clothing category",
                ImageUrl = "https://www.ernest.ca/cdn/shop/articles/Guide_Vestimentaire_3.png?v=1667419005&width=2048",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("69f22c76-7202-44e6-9132-09fd09c55632"),
                Name = "Women's Clothing",
                Status = CategoryStatus.Active,
                Description = "Women's Clothing category",
                ImageUrl =
                    "https://www.reiss.com/cms/resource/blob/976838/78c7ee422947a53d786b8deb107425fe/nybg-1-data.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"),
                Name = "Shoes",
                Status = CategoryStatus.Active,
                Description = "Shoes category",
                ImageUrl = "https://d1nymbkeomeoqg.cloudfront.net/photos/28/73/408849_7358_XL.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"),
                Name = "Accessories",
                Status = CategoryStatus.Active,
                Description = "Accessories category",
                ImageUrl =
                    "https://i0.wp.com/ordnur.com/wp-content/uploads/2023/06/Accessories-for-a-Trendy-Wardrobe.webp?ssl=1",
                ParentId = rootId
            }
        );
    }
}