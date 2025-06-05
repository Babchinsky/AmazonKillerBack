using AmazonKiller.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Reviews;

public static class ReviewLikesSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReviewLike>().HasData(
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000001"),
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                LikedAt = new DateTime(2024, 1, 1)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000001"),
                UserId = new Guid("b116a743-b108-494a-abb5-a0c9673edbef"),
                LikedAt = new DateTime(2024, 1, 2)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000002"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                LikedAt = new DateTime(2024, 1, 3)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000003"),
                UserId = new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"),
                LikedAt = new DateTime(2024, 1, 4)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000004"),
                UserId = new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"),
                LikedAt = new DateTime(2024, 1, 5)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000005"),
                UserId = new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"),
                LikedAt = new DateTime(2024, 1, 6)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000006"),
                UserId = new Guid("2583c105-264b-45ee-a535-3b939f4dd428"),
                LikedAt = new DateTime(2024, 1, 7)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000007"),
                UserId = new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"),
                LikedAt = new DateTime(2024, 1, 8)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000008"),
                UserId = new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"),
                LikedAt = new DateTime(2024, 1, 9)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000009"),
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                LikedAt = new DateTime(2024, 1, 10)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000010"),
                UserId = new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"),
                LikedAt = new DateTime(2024, 1, 11)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000011"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                LikedAt = new DateTime(2024, 1, 12)
            },
            new ReviewLike
            {
                ReviewId = new Guid("00000000-0000-0000-0000-000000000012"),
                UserId = new Guid("b116a743-b108-494a-abb5-a0c9673edbef"),
                LikedAt = new DateTime(2024, 1, 13)
            }
        );
    }
}