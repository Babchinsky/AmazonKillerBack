namespace AmazonKiller.Application.DTOs.Account.Orders;

public record OrderDto
{
    public Guid Id { get; init; }
    public string OrderNumber { get; init; } = string.Empty;
    public decimal TotalPrice { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime OrderedAt { get; init; }
    public string Email { get; init; } = string.Empty;
    public string DeliveryEmail { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Recipient { get; init; } = string.Empty;
    public string PaymentType { get; init; } = string.Empty;
}