using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;

public static class FashionCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03"),
                Name = "Fashion",
                Status = CategoryStatus.Active,
                Description = "Fashion category",
                ImageUrl = "https://example.com/images/fashion.jpg",
                IconName = "fashion",
                ParentId = null
            },
            new Category
            {
                Id = new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"),
                Name = "Men's Clothing",
                Status = CategoryStatus.Active,
                Description = "Men's Clothing category",
                ImageUrl = "https://example.com/images/mens_clothing.jpg",
                IconName = "men's clothing",
                ParentId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03")
            },
            new Category
            {
                Id = new Guid("69f22c76-7202-44e6-9132-09fd09c55632"),
                Name = "Women's Clothing",
                Status = CategoryStatus.Active,
                Description = "Women's Clothing category",
                ImageUrl = "https://example.com/images/womens_clothing.jpg",
                IconName = "women's clothing",
                ParentId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03")
            },
            new Category
            {
                Id = new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"),
                Name = "Shoes",
                Status = CategoryStatus.Active,
                Description = "Shoes category",
                ImageUrl = "https://example.com/images/shoes.jpg",
                IconName = "shoes",
                ParentId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03")
            },
            new Category
            {
                Id = new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"),
                Name = "Accessories",
                Status = CategoryStatus.Active,
                Description = "Accessories category",
                ImageUrl = "https://example.com/images/accessories.jpg",
                IconName = "accessories",
                ParentId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03")
            }
        );
    }
}