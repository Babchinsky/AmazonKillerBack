using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;

public static class HouseholdCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder, Dictionary<Guid, List<string>> keysMap)
    {
        var rootId = new Guid("8980e70c-3345-4885-8518-cfcda95b3078");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Household",
                Status = CategoryStatus.Active,
                Description = "Household category",
                ImageUrl = "https://example.com/images/household.jpg",
                IconName = "household",
                ParentId = null,
                PropertyKeys = SeedHelper.KeysOrNull(rootId, keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"),
                Name = "Kitchen Appliances",
                Status = CategoryStatus.Active,
                Description = "Kitchen Appliances category",
                ImageUrl = "https://example.com/images/kitchen_appliances.jpg",
                IconName = "kitchen appliances",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("0e6feb3f-f795-4541-8cc6-7d7047951eb9"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("1b6f5f96-233d-4b82-b30f-27643f6b62eb"),
                Name = "Cleaning Supplies",
                Status = CategoryStatus.Active,
                Description = "Cleaning Supplies category",
                ImageUrl = "https://example.com/images/cleaning_supplies.jpg",
                IconName = "cleaning supplies",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("1b6f5f96-233d-4b82-b30f-27643f6b62eb"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"),
                Name = "Storage",
                Status = CategoryStatus.Active,
                Description = "Storage category",
                ImageUrl = "https://example.com/images/storage.jpg",
                IconName = "storage",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("d94af679-24f4-4ab2-ae1e-ba3689143579"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"),
                Name = "Bathroom",
                Status = CategoryStatus.Active,
                Description = "Bathroom category",
                ImageUrl = "https://example.com/images/bathroom.jpg",
                IconName = "bathroom",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("2f4f0438-f456-4770-9d49-1a46ed4ec88a"), keysMap) ?? []
            }
        );
    }
}