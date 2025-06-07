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
                ImageUrl =
                    "https://hpp.arkema.com/files/live/sites/shared_arkema/files/images/markets/Electronics%20electrical/electronics.jpg",
                IconName = "computer"
            },
            new Category
            {
                Id = new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
                Name = "Smartphones",
                Status = CategoryStatus.Active,
                Description = "Smartphones category",
                ImageUrl = "https://cdn.mos.cms.futurecdn.net/M4nigVN3vvA5EEnNX9atxY-1200-80.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("22e7ee0d-8962-482b-857d-43ba828de1ff"),
                Name = "Laptops",
                Status = CategoryStatus.Active,
                Description = "Laptops category",
                ImageUrl =
                    "https://cdn.thewirecutter.com/wp-content/media/2024/07/laptopstopicpage-2048px-3685-3x2-1.jpg?auto=webp&quality=75&crop=1.91:1&width=1200",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("8fc8707d-97d7-41a1-9c31-50f07b8466f4"),
                Name = "Cameras",
                Status = CategoryStatus.Active,
                Description = "Cameras category",
                ImageUrl =
                    "https://i.rtings.com/assets/pages/GnRRKSpc/best-cameras-for-photography-20230911-medium.jpg?format=auto",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                Name = "Audio Devices",
                Status = CategoryStatus.Active,
                Description = "Audio Devices category",
                ImageUrl =
                    "https://o.aolcdn.com/hss/storage/midas/9bba15694f672222afc0741fe8c6011b/201309450/audio.png",
                ParentId = rootId
            }
        );
    }
}