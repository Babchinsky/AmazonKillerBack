namespace AmazonKiller.Application.DTOs.Orders;

public record OrderDetailsDto
{
    public Guid Id { get; init; }
    public string OrderNumber { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime OrderedAt { get; init; }
    public string Address { get; init; } = string.Empty;
    public string Recipient { get; init; } = string.Empty;
    public string PaymentType { get; init; } = string.Empty;
    public List<OrderItemDto> Items { get; init; } = [];
}