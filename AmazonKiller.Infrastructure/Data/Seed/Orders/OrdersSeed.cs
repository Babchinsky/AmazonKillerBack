using AmazonKiller.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Data.Seed.Orders;

public static class OrdersSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        /* ----------------------- Orders (без навигаций) ----------------------- */
        modelBuilder.Entity<Order>().HasData(
            new Order
            {
                Id = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"),
                UserId = Guid.Parse("7a612c2e-ebc1-4a30-ac54-cccb566a1086"),
                OrderNumber = "ORD-1001",
                TotalPrice = 139.98m,
                Status = OrderStatus.Ordered,
                Info = null!,
                Items = null!
            },
            new Order
            {
                Id = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                UserId = Guid.Parse("fa67eef0-62a7-4e61-83ef-5a054e84ce41"),
                OrderNumber = "ORD-1002",
                TotalPrice = 1489.96m,
                Status = OrderStatus.Ordered,
                Info = null!,
                Items = null!
            },
            new Order
            {
                Id = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"),
                UserId = Guid.Parse("82bf572a-ab40-4571-b1a2-ec9dcf9ccb7d"),
                OrderNumber = "ORD-1003",
                TotalPrice = 689.97m,
                Status = OrderStatus.Ordered,
                Info = null!,
                Items = null!
            }
        );

        /* --------------------- OrderInfo (owned-entity) ----------------------- */
        modelBuilder.Entity<Order>().OwnsOne(o => o.Info, info =>
        {
            info.WithOwner().HasForeignKey("OrderId");

            info.HasData(
                new
                {
                    OrderId = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"),
                    Id = Guid.Parse("00000000-0000-0000-0000-00000000c001"), OrderedAt = new DateTime(2024, 1, 1)
                },
                new
                {
                    OrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                    Id = Guid.Parse("00000000-0000-0000-0000-00000000c002"), OrderedAt = new DateTime(2024, 1, 2)
                },
                new
                {
                    OrderId = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"),
                    Id = Guid.Parse("00000000-0000-0000-0000-00000000c003"), OrderedAt = new DateTime(2024, 1, 3)
                }
            );

            /* ------------------- DeliveryInfo (owned) ----------------------- */
            info.OwnsOne(i => i.Delivery, delivery =>
            {
                delivery.WithOwner().HasForeignKey("OrderInfoOrderId");

                delivery.HasData(
                    new
                    {
                        OrderInfoOrderId = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"), FirstName = "Pavlo",
                        LastName = "Babchynskyi", Email = "pavlo@example.com"
                    },
                    new
                    {
                        OrderInfoOrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"), FirstName = "Olena",
                        LastName = "Rudenko", Email = "olena@example.com"
                    },
                    new
                    {
                        OrderInfoOrderId = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"), FirstName = "Ivan",
                        LastName = "Petrenko", Email = "ivan@example.com"
                    }
                );

                /* ---------------- Address (owned) -------------------------- */
                delivery.OwnsOne(d => d.Address).HasData(
                    new
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000a01"),
                        DeliveryInfoOrderInfoOrderId = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"),
                        Country = "Ukraine", City = "Odessa", Street = "Main St", HouseNumber = "123A",
                        PostCode = "65000"
                    },
                    new
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000a02"),
                        DeliveryInfoOrderInfoOrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                        Country = "Ukraine", City = "Kyiv", Street = "Central Ave", HouseNumber = "45B",
                        PostCode = "02000"
                    },
                    new
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000a03"),
                        DeliveryInfoOrderInfoOrderId = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"),
                        Country = "Ukraine", City = "Lviv", Street = "Green Blvd", HouseNumber = "78C",
                        PostCode = "79000"
                    }
                );
            });

            /* ------------------- PaymentInfo (owned) ---------------------- */
            info.OwnsOne(i => i.Payment).HasData(
                new
                {
                    OrderInfoOrderId = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"),
                    PaymentType = PaymentType.Card, CardNumber = "4111111111111111", ExpirationDate = "12/25",
                    Cvv = "123"
                },
                new
                {
                    OrderInfoOrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                    PaymentType = PaymentType.Cash, CardNumber = (string?)null, ExpirationDate = (string?)null,
                    Cvv = (string?)null
                },
                new
                {
                    OrderInfoOrderId = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"),
                    PaymentType = PaymentType.Card, CardNumber = "5555555555554444", ExpirationDate = "08/26",
                    Cvv = "456"
                }
            );
        });

        /* ----------------------- OrderItems ------------------------------- */
        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000b001"),
                OrderId = Guid.Parse("8d39ee25-6be0-46aa-8a1f-75407bd3fa0d"),
                ProductId = Guid.Parse("b416e570-f438-4c53-9dd1-1b8388dd181b"),
                Quantity = 2,
                Price = 69.99m,
                OrderedAt = new DateTime(2024, 1, 1)
            },
            new OrderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000b002"),
                OrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                ProductId = Guid.Parse("3c5a4868-3b2d-4352-9e12-502a56bce48a"),
                Quantity = 1,
                Price = 1199.99m,
                OrderedAt = new DateTime(2024, 1, 2)
            },
            new OrderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000b003"),
                OrderId = Guid.Parse("2f2339d3-98a9-4039-b5fe-fa6d8e9d66ba"),
                ProductId = Guid.Parse("74a46f1c-1054-408d-89dc-8ca00285660f"),
                Quantity = 2,
                Price = 149.99m,
                OrderedAt = new DateTime(2024, 1, 2)
            },
            new OrderItem
            {
                Id = Guid.Parse("00000000-0000-0000-0000-00000000b004"),
                OrderId = Guid.Parse("4e6f98ed-d665-470b-992b-dd872c86abe2"),
                ProductId = Guid.Parse("4c73d114-2aa1-4f4c-aa7a-48038f1f95fc"),
                Quantity = 3,
                Price = 229.99m,
                OrderedAt = new DateTime(2024, 1, 3)
            }
        );
    }
}