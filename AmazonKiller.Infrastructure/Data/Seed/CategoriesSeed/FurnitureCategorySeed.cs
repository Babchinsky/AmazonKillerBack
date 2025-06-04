using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;

public static class FurnitureCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder, Dictionary<Guid, List<string>> keysMap)
    {
        var rootId = new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Furniture",
                Status = CategoryStatus.Active,
                Description = "Furniture category",
                ImageUrl = "https://example.com/images/furniture.jpg",
                IconName = "furniture",
                ParentId = null
            },
            new Category
            {
                Id = new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"),
                Name = "Living Room",
                Status = CategoryStatus.Active,
                Description = "Living Room category",
                ImageUrl = "https://example.com/images/living_room.jpg",
                IconName = "living room",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"),
                Name = "Bedroom",
                Status = CategoryStatus.Active,
                Description = "Bedroom category",
                ImageUrl = "https://example.com/images/bedroom.jpg",
                IconName = "bedroom",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("c9f81657-73a1-4b53-bf80-b59121eae433"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"),
                Name = "Office Furniture",
                Status = CategoryStatus.Active,
                Description = "Office Furniture category",
                ImageUrl = "https://example.com/images/office_furniture.jpg",
                IconName = "office furniture",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"),
                Name = "Outdoor",
                Status = CategoryStatus.Active,
                Description = "Outdoor category",
                ImageUrl = "https://example.com/images/outdoor.jpg",
                IconName = "outdoor",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"), keysMap) ?? []
            }
        );
    }
}