using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CategoriesSeed;

public static class WorkToolsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                Name = "Work tools",
                Status = CategoryStatus.Active,
                Description = "Work tools category",
                ImageUrl = "https://example.com/images/worktools.jpg",
                IconName = "work tools",
                ParentId = null
            },
            new Category
            {
                Id = new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"),
                Name = "Hand Tools",
                Status = CategoryStatus.Active,
                Description = "Hand Tools category",
                ImageUrl = "https://example.com/images/hand_tools.jpg",
                IconName = "hand tools",
                ParentId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2")
            },
            new Category
            {
                Id = new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
                Name = "Power Tools",
                Status = CategoryStatus.Active,
                Description = "Power Tools category",
                ImageUrl = "https://example.com/images/power_tools.jpg",
                IconName = "power tools",
                ParentId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2")
            },
            new Category
            {
                Id = new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"),
                Name = "Safety Gear",
                Status = CategoryStatus.Active,
                Description = "Safety Gear category",
                ImageUrl = "https://example.com/images/safety_gear.jpg",
                IconName = "safety gear",
                ParentId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2")
            },
            new Category
            {
                Id = new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"),
                Name = "Tool Storage",
                Status = CategoryStatus.Active,
                Description = "Tool Storage category",
                ImageUrl = "https://example.com/images/tool_storage.jpg",
                IconName = "tool storage",
                ParentId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2")
            }
        );
    }
}