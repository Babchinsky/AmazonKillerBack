using AmazonKiller.Domain.Entities.Orders;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<Guid>
{
    // Recipient
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // Address
    public string Country { get; set; } = string.Empty;
    public string? State { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNumber { get; set; } = string.Empty;
    public string? ApartmentNumber { get; set; }
    public string PostCode { get; set; } = string.Empty;

    // Payment
    public PaymentType PaymentType { get; set; }
    public string? CardNumber { get; set; }
    public string? ExpirationDate { get; set; }
    public string? Cvv { get; set; }
}