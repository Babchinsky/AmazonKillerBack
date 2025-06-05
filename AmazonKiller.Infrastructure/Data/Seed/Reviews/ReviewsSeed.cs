using AmazonKiller.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Reviews;

public static class ReviewsSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasData(
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000001"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                UserId = new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"),
                Article = "Excellent phone",
                Message = "Battery lasts all day. The screen is incredibly bright and vivid.",
                Rating = 5.0m,
                ImageUrls = [],
                Tags = ["battery", "screen"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000002"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                Article = "Good but expensive",
                Message = "Features are great, but the price is a bit high.",
                Rating = 4.0m,
                ImageUrls = [],
                Tags = ["price"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000003"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                UserId = new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"),
                Article = "Top sound quality",
                Message = "Perfect for flights. Noise cancelling works like magic.",
                Rating = 5.0m,
                ImageUrls = [],
                Tags = ["sound", "noise cancelling"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000004"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                UserId = new Guid("b116a743-b108-494a-abb5-a0c9673edbef"),
                Article = "Comfortable",
                Message = "Long usage with no discomfort. Battery could be better though.",
                Rating = 4.2m,
                ImageUrls = [],
                Tags = ["comfort", "battery"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000005"),
                ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                UserId = new Guid("2583c105-264b-45ee-a535-3b939f4dd428"),
                Article = "Stylish and solid",
                Message = "Looks very elegant and feels sturdy. Love the natural finish.",
                Rating = 4.7m,
                ImageUrls = [],
                Tags = ["design", "durability"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000006"),
                ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
                UserId = new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"),
                Article = "Beast of a drill",
                Message = "Very powerful and long-lasting battery. Great for home use.",
                Rating = 5.0m,
                ImageUrls = [],
                Tags = ["power", "performance"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000007"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                UserId = new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"),
                Article = "Classic style",
                Message = "Fits perfectly and looks good with anything. My go-to jacket.",
                Rating = 4.9m,
                ImageUrls = [],
                Tags = ["fit", "style"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000008"),
                ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
                UserId = new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"),
                Article = "Impressive cleaning",
                Message = "Powerful suction and laser feature is actually helpful.",
                Rating = 4.8m,
                ImageUrls = [],
                Tags = ["vacuum", "laser"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000009"),
                ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                UserId = new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"),
                Article = "Simple and elegant",
                Message = "Easy to assemble, light weight, looks clean and modern.",
                Rating = 4.6m,
                ImageUrls = [],
                Tags = ["design", "assembly"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000010"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                Article = "Camera is next level",
                Message = "200MP might be overkill, but wow, it delivers detail.",
                Rating = 4.9m,
                ImageUrls = [],
                Tags = ["camera"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000011"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                UserId = new Guid("2583c105-264b-45ee-a535-3b939f4dd428"),
                Article = "Good value",
                Message = "High-quality fabric, didn’t expect it for this price.",
                Rating = 4.4m,
                ImageUrls = [],
                Tags = ["value", "material"]
            },
            new Review
            {
                Id = new Guid("00000000-0000-0000-0000-000000000012"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                Article = "Not for running",
                Message = "Slips off easily if you're jogging. Great otherwise.",
                Rating = 3.9m,
                ImageUrls = [],
                Tags = ["use case"]
            }
        );
    }
}