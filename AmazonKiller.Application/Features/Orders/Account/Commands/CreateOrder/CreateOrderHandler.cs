using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Repositories.Payments;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Orders.Account.Commands.CreateOrder;

public class CreateOrderHandler(
    IOrderRepository orderRepo,
    ICartRepository cartRepo,
    IAccountRepository accountRepo,
    IProductRepository productRepo,
    ICurrentUserService currentUserService,
    ISequenceService sequenceService,
    IPaymentService paymentService)
    : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand req, CancellationToken ct)
    {
        var userId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var cartItems = await cartRepo.GetCartItemsWithProductsAsync(userId, ct);
        if (cartItems.Count == 0)
            throw new AppException("Cart is empty");

        var nextNumber = await sequenceService.GetNextAsync("Order", ct);
        var orderNumber = $"#{nextNumber:D6}";

        var order = new Order
        {
            UserId = userId,
            OrderNumber = orderNumber,
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
                OrderedAt = DateTime.UtcNow
            }).ToList()
        };

        order.TotalPrice = order.Items.Sum(x => x.Price * x.Quantity);

        foreach (var item in order.Items)
        {
            var product = await productRepo.GetByIdAsync(item.ProductId, ct);
            if (product is null) continue;

            if (product.Quantity < item.Quantity)
                throw new AppException($"Not enough stock for product '{product.Name}'");

            product.SoldCount += item.Quantity;
            product.Quantity -= item.Quantity;
        }

        if (req.PaymentType == PaymentType.Card)
        {
            var paymentMethodId = req.StripePaymentMethodId ?? "pm_card_visa";

            var paymentIntentId = await paymentService.CreatePaymentIntentAsync(
                order.TotalPrice,
                paymentMethodId
            );

            var confirmed = await paymentService.ConfirmPaymentAsync(paymentIntentId);

            if (!confirmed)
                throw new AppException("Card payment failed.");
        }

        var orderId = await orderRepo.CreateOrderAsync(order, ct);
        await cartRepo.ClearCartAsync(userId, ct);
        return orderId;
    }
}