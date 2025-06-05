using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class WorkToolsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder, Dictionary<Guid, List<string>> keysMap)
    {
        var rootId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Work tools",
                Status = CategoryStatus.Active,
                Description = "Work tools category",
                ImageUrl = "https://example.com/images/worktools.jpg",
                IconName = "work tools",
                ParentId = null,
                PropertyKeys = SeedHelper.KeysOrNull(rootId, keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"),
                Name = "Hand Tools",
                Status = CategoryStatus.Active,
                Description = "Hand Tools category",
                ImageUrl = "https://example.com/images/hand_tools.jpg",
                IconName = "hand tools",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("834ba378-fe57-4702-b85c-4cb0431d1909"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
                Name = "Power Tools",
                Status = CategoryStatus.Active,
                Description = "Power Tools category",
                ImageUrl = "https://example.com/images/power_tools.jpg",
                IconName = "power tools",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("1c9d0336-9ac8-440a-b6b6-3698940f608c"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"),
                Name = "Safety Gear",
                Status = CategoryStatus.Active,
                Description = "Safety Gear category",
                ImageUrl = "https://example.com/images/safety_gear.jpg",
                IconName = "safety gear",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("18710447-a260-44f2-9a4b-77c0b246bbc5"), keysMap) ?? []
            },
            new Category
            {
                Id = new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"),
                Name = "Tool Storage",
                Status = CategoryStatus.Active,
                Description = "Tool Storage category",
                ImageUrl = "https://example.com/images/tool_storage.jpg",
                IconName = "tool storage",
                ParentId = rootId,
                PropertyKeys = SeedHelper.KeysOrNull(Guid.Parse("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"), keysMap) ?? []
            }
        );
    }
}