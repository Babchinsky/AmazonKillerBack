using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Wishlists;

public static class WishlistsSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wishlist>().HasData(
            new Wishlist
            {
                UserId = new Guid("7a612c2e-ebc1-4a30-ac54-cccb566a1086"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                AddedAt = new DateTime(2024, 1, 1)
            },
            new Wishlist
            {
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                AddedAt = new DateTime(2024, 1, 2)
            },
            new Wishlist
            {
                UserId = new Guid("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                AddedAt = new DateTime(2024, 1, 3)
            },
            new Wishlist
            {
                UserId = new Guid("b116a743-b108-494a-abb5-a0c9673edbef"),
                ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                AddedAt = new DateTime(2024, 1, 4)
            },
            new Wishlist
            {
                UserId = new Guid("2583c105-264b-45ee-a535-3b939f4dd428"),
                ProductId = new Guid("a055168e-3130-4b0a-8495-60e25d62e057"),
                AddedAt = new DateTime(2024, 1, 5)
            },
            new Wishlist
            {
                UserId = new Guid("741ddf70-bcb9-44ba-a666-246072dd8c82"),
                ProductId = new Guid("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
                AddedAt = new DateTime(2024, 1, 6)
            },
            new Wishlist
            {
                UserId = new Guid("4f33466b-00cd-424d-9c5a-2356d9fc179d"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                AddedAt = new DateTime(2024, 1, 7)
            },
            new Wishlist
            {
                UserId = new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                AddedAt = new DateTime(2024, 1, 8)
            },
            new Wishlist
            {
                UserId = new Guid("9f73b2c1-71c7-434b-8fcd-b3ca7a6eae98"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                AddedAt = new DateTime(2024, 1, 9)
            },
            new Wishlist
            {
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                ProductId = new Guid("74a46f1c-1054-408d-89dc-8ca00285660f"),
                AddedAt = new DateTime(2024, 1, 10)
            }
        );
    }
}