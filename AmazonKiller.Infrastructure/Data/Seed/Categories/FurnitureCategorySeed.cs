using AmazonKiller.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Categories;

public static class FurnitureCategorySeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var rootId = new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf");

        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = rootId,
                Name = "Furniture",
                Status = CategoryStatus.Active,
                Description = "Furniture category",
                ImageUrl =
                    "https://www.livingdesignsfurniture.com/wp-content/uploads/2022/03/shutterstock_1929872735-1.webp",
                IconName = "sofa"
            },
            new Category
            {
                Id = new Guid("68ae1c83-85c1-4002-bb32-d00ac9b3a1bb"),
                Name = "Living Room",
                Status = CategoryStatus.Active,
                Description = "Living Room category",
                ImageUrl =
                    "https://hgtvhome.sndimg.com/content/dam/images/hgtv/fullset/2023/7/19/3/DOTY2023_Dramatic-Before-And-Afters_Hidden-Hills-11.jpg.rend.hgtvcom.1280.720.85.suffix/1689786863909.webp",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("c9f81657-73a1-4b53-bf80-b59121eae433"),
                Name = "Bedroom",
                Status = CategoryStatus.Active,
                Description = "Bedroom category",
                ImageUrl =
                    "https://www.thespruce.com/thmb/HrWPmUEjB_yA71L6OJjiQPPvov4=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/master-bedroom-in-new-luxury-home-with-chandelier-and-large-bank-of-windows-with-view-of-trees-1222623844-212940f4f89e4b69b6ce56fd968e9351.jpg",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("2f3ad03d-c8a3-4c12-bf7c-db764e634fc4"),
                Name = "Office Furniture",
                Status = CategoryStatus.Active,
                Description = "Office Furniture category",
                ImageUrl = "https://smartspace.com.ua/userfls/shop/categori_id/3276_mebel-dlya-ofisa.webp",
                ParentId = rootId
            },
            new Category
            {
                Id = new Guid("7f3e369a-0b7d-4178-84bf-e4194fac9ed2"),
                Name = "Outdoor",
                Status = CategoryStatus.Active,
                Description = "Outdoor category",
                ImageUrl =
                    "https://media.johnlewiscontent.com/i/JohnLewis/outdoors-outdoorfurniture-inspire-gb-200223?fmt=auto",
                ParentId = rootId
            }
        );
    }
}