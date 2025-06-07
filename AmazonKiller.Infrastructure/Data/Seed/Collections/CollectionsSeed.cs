using AmazonKiller.Domain.Entities.Collections;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Collections;

public static class CollectionsSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Collection>().HasData(
            new Collection
            {
                Id = new Guid("10000000-0000-0000-0000-000000000001"),
                Title = "Galaxy Highlights",
                CategoryId = new Guid("d2deb989-35c5-4ca1-a748-12411d3ac3a4"),
                ImageUrl = "https://www.sammyfans.com/wp-content/uploads/2025/03/one-ui-7-intuitive-img.jpg",
                MinPrice = 1000,
                MaxPrice = 1300
            },
            new Collection
            {
                Id = new Guid("10000000-0000-0000-0000-000000000002"),
                Title = "Sony Audio Bestsellers",
                CategoryId = new Guid("c1cd879d-175e-4ff5-b354-054f9f82ce98"),
                ImageUrl =
                    "https://cdn.shopify.com/s/files/1/0340/3975/8907/products/WH1000XM5B_1.jpg?v=1652359353&width=364",
                MinPrice = 300,
                MaxPrice = 400
            },
            new Collection
            {
                Id = new Guid("10000000-0000-0000-0000-000000000003"),
                Title = "Denim Essentials",
                CategoryId = new Guid("7eb489f4-2f55-4510-8e49-3965370c4989"),
                ImageUrl = "https://www.thefactshop.com/wp-content/uploads/2016/11/denim-jeans-facts.jpg",
                MinPrice = 50,
                MaxPrice = 100
            },
            new Collection
            {
                Id = new Guid("10000000-0000-0000-0000-000000000004"),
                Title = "Modern Coffee Tables",
                CategoryId = new Guid("0dfa0836-09c9-4a2d-b74a-9b2085976dcf"),
                ImageUrl =
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTnroSazOZgAVDY26rzWBoIGhKhi7s5JDOgAw&s",
                MinPrice = 120,
                MaxPrice = 160
            },
            new Collection
            {
                Id = new Guid("10000000-0000-0000-0000-000000000005"),
                Title = "Makita Power Tools",
                CategoryId = new Guid("cc9bf323-2160-49b2-ae79-340781163eb2"),
                ImageUrl =
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-kEDvzQ7aygIbrsTVd6vMex27pGFF1nj_Og&s",
                MinPrice = 200,
                MaxPrice = 250
            }
        );

        modelBuilder.Entity<Collection>().OwnsMany(c => c.Filters).HasData(
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000001"), Key = "Battery", Value = "5000mAh" },
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000001"), Key = "Camera", Value = "200MP" },
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000001"), Key = "Storage", Value = "256GB" },
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000002"), Key = "Type", Value = "Over-ear" },
            new
            {
                CollectionId = new Guid("10000000-0000-0000-0000-000000000002"), Key = "Noise Cancellation",
                Value = "Yes"
            },
            new
            {
                CollectionId = new Guid("10000000-0000-0000-0000-000000000003"), Key = "Material", Value = "100% Cotton"
            },
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000003"), Key = "Fit", Value = "Regular" },
            new
            {
                CollectionId = new Guid("10000000-0000-0000-0000-000000000004"), Key = "Material", Value = "Oak wood"
            },
            new
            {
                CollectionId = new Guid("10000000-0000-0000-0000-000000000004"), Key = "Finish",
                Value = "Natural varnish"
            },
            new { CollectionId = new Guid("10000000-0000-0000-0000-000000000005"), Key = "Voltage", Value = "18V" },
            new
            {
                CollectionId = new Guid("10000000-0000-0000-0000-000000000005"), Key = "Battery",
                Value = "2 x 5.0Ah Li-ion"
            }
        );
    }
}