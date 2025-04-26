using AmazonKiller.Application.Interfaces.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;

public class CreateOrderHandler(
    IOrderRepository repo,
    ICurrentUserService currentUser
) : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken ct)
    {
        if (currentUser.UserId is not { } userId)
            throw new UnauthorizedAccessException("User is not authenticated");

        var delivery = new DeliveryInfo
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Address = new Address
            {
                Country = request.Country,
                State = request.State,
                City = request.City,
                Street = request.Street,
                HouseNumber = request.HouseNumber,
                ApartmentNumber = request.ApartmentNumber,
                PostCode = request.PostCode
            }
        };

        var payment = new PaymentInfo
        {
            PaymentType = request.PaymentType,
            CardNumber = request.PaymentType == PaymentType.Card ? request.CardNumber : null,
            ExpirationDate = request.PaymentType == PaymentType.Card ? request.ExpirationDate : null,
            Cvv = request.PaymentType == PaymentType.Card ? request.Cvv : null
        };

        var order = new Order
        {
            Info = new OrderInfo
            {
                Delivery = delivery,
                Payment = payment,
                OrderedAt = DateTime.UtcNow
            },
            UserId = userId,
            Status = OrderStatus.Ordered,
            TotalPrice = 0
        };

        await repo.CreateOrderAsync(order, ct);
        return order.Id;
    }
}