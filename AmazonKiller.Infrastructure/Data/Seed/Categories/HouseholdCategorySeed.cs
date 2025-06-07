using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class HouseholdCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var rootId = new Guid("8980e70c-3345-4885-8518-cfcda95b3078");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Household",
                Status = CategoryStatus.Active,
                Description = "Household category",
                ImageUrl = "https://t3.ftcdn.net/jpg/01/91/32/34/360_F_191323402_W2ATUPr8dGHALHrvyX4WVlEDz4qXmmd9.jpg",
                IconName = "cleaning-spray"
            },
            new Category
            {
                Id = new Guid("0e6feb3f-f795-4541-8cc6-7d7047951eb9"),
                Name = "Kitchen Appliances",
                Status = CategoryStatus.Active,
                Description = "Kitchen Appliances category",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ45ouTZfVpls_4kIUvr3-TvaJZUg6_OhRrDg&s",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("1b6f5f96-233d-4b82-b30f-27643f6b62eb"),
                Name = "Cleaning Supplies",
                Status = CategoryStatus.Active,
                Description = "Cleaning Supplies category",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-HIah6yp0_WEhhmZjZeHwdFh5PA5geutGcw&s",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("d94af679-24f4-4ab2-ae1e-ba3689143579"),
                Name = "Storage",
                Status = CategoryStatus.Active,
                Description = "Storage category",
                ImageUrl = "https://www.veegaland.com/wp-content/uploads/2021/10/EFFICIENT-HOME-STORAGE-IDEAS-AND-TIPS-FOR-A-WELL-ORGANIZED-INTERIOR.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("2f4f0438-f456-4770-9d49-1a46ed4ec88a"),
                Name = "Bathroom",
                Status = CategoryStatus.Active,
                Description = "Bathroom category",
                ImageUrl = "https://orion180.com/wp-content/uploads/2023/06/AdobeStock_394532332.jpeg",
                ParentId = rootId
            }
        );
    }
}