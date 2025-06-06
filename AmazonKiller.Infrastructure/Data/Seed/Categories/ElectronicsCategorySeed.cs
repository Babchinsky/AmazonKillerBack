using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class ElectronicsCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var rootId = new Guid("7ad3d843-1642-4e8a-a843-503928ef8154");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Electronics",
                Status = CategoryStatus.Active,
                Description = "Electronics category",
                ImageUrl = "https://example.com/images/electronics.jpg",
                IconName = "computer",
                ParentId = null,
            },
            new Category
            {
                Id = new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
                Name = "Smartphones",
                Status = CategoryStatus.Active,
                Description = "Smartphones category",
                ImageUrl = "https://example.com/images/smartphones.jpg",
                IconName = "smartphones",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"),
                Name = "Laptops",
                Status = CategoryStatus.Active,
                Description = "Laptops category",
                ImageUrl = "https://example.com/images/laptops.jpg",
                IconName = "laptops",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"),
                Name = "Cameras",
                Status = CategoryStatus.Active,
                Description = "Cameras category",
                ImageUrl = "https://example.com/images/cameras.jpg",
                IconName = "cameras",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                Name = "Audio Devices",
                Status = CategoryStatus.Active,
                Description = "Audio Devices category",
                ImageUrl = "https://example.com/images/audio_devices.jpg",
                IconName = "audio devices",
                ParentId = rootId
            }
        );
    }
}