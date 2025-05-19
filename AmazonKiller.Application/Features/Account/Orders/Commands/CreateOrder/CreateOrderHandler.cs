using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;

public class CreateOrderHandler(
    IOrderRepository orderRepo,
    ICartRepository cartRepo,
    IProductRepository productRepo,
    ICurrentUserService currentUser,
    DbContext dbContext)
    : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand req, CancellationToken ct)
    {
        var userId = currentUser.UserId ?? throw new UnauthorizedAccessException("User is not authenticated");

        var cartItems = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);
        if (cartItems.Count == 0) throw new AppException("Cart is empty");

        var order = new Order
        {
            UserId = userId,
            Status = OrderStatus.Ordered,
            Info = new OrderInfo
            {
                OrderedAt = DateTime.UtcNow,
                Delivery = new DeliveryInfo
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Email = req.Email,
                    Address = new Address
                    {
                        Country = req.Country,
                        State = req.State,
                        City = req.City,
                        Street = req.Street,
                        HouseNumber = req.HouseNumber,
                        ApartmentNumber = req.ApartmentNumber,
                        PostCode = req.PostCode
                    }
                },
                Payment = new PaymentInfo
                {
                    PaymentType = req.PaymentType,
                    CardNumber = req.PaymentType == PaymentType.Card ? req.CardNumber : null,
                    ExpirationDate = req.PaymentType == PaymentType.Card ? req.ExpirationDate : null,
                    Cvv = req.PaymentType == PaymentType.Card ? req.Cvv : null
                }
            },
            Items = cartItems.Select(i => new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = i.ProductId,
                Price = i.Price,
                Quantity = i.Quantity,
                OrderedAt = DateTime.UtcNow,
                Status = OrderStatus.Ordered
            }).ToList()
        };

        order.TotalPrice = order.Items.Sum(x => x.Price * x.Quantity);

        // Инкрементируем SoldCount в одном SaveChangesAsync
        foreach (var item in order.Items)
        {
            var product = await productRepo.GetByIdAsync(item.ProductId, ct);
            if (product is not null)
                product.SoldCount += item.Quantity;
        }

        var orderId = await orderRepo.CreateOrderAsync(order, ct);
        await cartRepo.ClearCartAsync(userId, ct);
        await dbContext.SaveChangesAsync(ct); // один SaveChanges

        return orderId;
    }
}