using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.CartLists;

public static class CartListSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartList>().HasData(
            new CartList
            {
                Id = new Guid("c51758a1-f536-463b-a921-cc9206a34927"),
                UserId = new Guid("0986d7ae-31ff-42d8-a9d4-450625e8dd76"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                Quantity = 2,
                Price = 69.99m,
                AddedAt = new DateTime(2024, 1, 30)
            },
            new CartList
            {
                Id = new Guid("a2437747-dfe4-4d24-8cdf-5e44abbd2c7f"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                Quantity = 3,
                Price = 1199.99m,
                AddedAt = new DateTime(2024, 1, 19)
            },
            new CartList
            {
                Id = new Guid("ab6454d8-69c2-4e81-8313-d2cdc0b1cf9c"),
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                ProductId = new Guid("a2c28a83-cfea-46ee-87e3-906f9e90f1aa"),
                Quantity = 3,
                Price = 349.99m,
                AddedAt = new DateTime(2024, 1, 4)
            },
            new CartList
            {
                Id = new Guid("229de273-0066-4a4a-8678-21eb61416578"),
                UserId = new Guid("a4f0b9c1-47e8-46ff-a9e5-d388693cffef"),
                ProductId = new Guid("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                Quantity = 1,
                Price = 69.99m,
                AddedAt = new DateTime(2024, 1, 20)
            },
            new CartList
            {
                Id = new Guid("85caea79-0bb1-4649-9102-142eb37c7664"),
                UserId = new Guid("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                ProductId = new Guid("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                Quantity = 1,
                Price = 1199.99m,
                AddedAt = new DateTime(2024, 1, 6)
            }
        );
    }
}