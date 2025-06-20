﻿using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class WorkToolsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var rootId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Work tools",
                Status = CategoryStatus.Active,
                Description = "Work tools category",
                ImageUrl =
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQwO5jLC0Dtm27AcDKo8DAt57_M3tSpZCOmxA&s",
                IconName = "hammer"
            },
            new Category
            {
                Id = new Guid("834ba378-fe57-4702-b85c-4cb0431d1909"),
                Name = "Hand Tools",
                Status = CategoryStatus.Active,
                Description = "Hand Tools category",
                ImageUrl = "",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("1c9d0336-9ac8-440a-b6b6-3698940f608c"),
                Name = "Power Tools",
                Status = CategoryStatus.Active,
                Description = "Power Tools category",
                ImageUrl =
                    "https://ik.imagekit.io/fepy/cdn/magefan_blog/2023/08/best_power_tool_sets_hero_image-scaled.jpeg.optimal.jpeg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("18710447-a260-44f2-9a4b-77c0b246bbc5"),
                Name = "Safety Gear",
                Status = CategoryStatus.Active,
                Description = "Safety Gear category",
                ImageUrl = "https://www.build-review.com/wp-content/uploads/2021/04/PPE.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("158ebe6b-0e3d-48da-8893-5e3621dd2c4b"),
                Name = "Tool Storage",
                Status = CategoryStatus.Active,
                Description = "Tool Storage category",
                ImageUrl = "https://m.media-amazon.com/images/I/81fEQF48dIL.jpg",
                ParentId = rootId
            }
        );
    }
}