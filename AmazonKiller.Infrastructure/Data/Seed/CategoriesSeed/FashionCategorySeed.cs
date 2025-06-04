using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;

public static class FashionCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder, Dictionary<Guid, List<string>> keysMap)
    {
        var rootId = new Guid("49595c91-f315-4b2e-af8a-0f09c3145c03");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
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
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("7eb489f4-2f55-4510-8e49-3965370c4989"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("69f22c76-7202-44e6-9132-09fd09c55632"),
                Name = "Women's Clothing",
                Status = CategoryStatus.Active,
                Description = "Women's Clothing category",
                ImageUrl = "https://example.com/images/womens_clothing.jpg",
                IconName = "women's clothing",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("69f22c76-7202-44e6-9132-09fd09c55632"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"),
                Name = "Shoes",
                Status = CategoryStatus.Active,
                Description = "Shoes category",
                ImageUrl = "https://example.com/images/shoes.jpg",
                IconName = "shoes",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("be4e31b6-3b78-4d99-a3fa-7cb8a7bc4a8b"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"),
                Name = "Accessories",
                Status = CategoryStatus.Active,
                Description = "Accessories category",
                ImageUrl = "https://example.com/images/accessories.jpg",
                IconName = "accessories",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("3b464a7d-878c-4b8b-b44f-c78a2b59be3a"), keysMap) ?? []
            }
        );
    }
}