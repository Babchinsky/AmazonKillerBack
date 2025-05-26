namespace AmazonKiller.Application.DTOs.Account.Orders;

public record OrderDto
{
    public Guid Id { get; init; }
    public decimal TotalPrice { get; init; }
    public string Status { get; init; } = string.Empty;
    public DateTime OrderedAt { get; init; }
    public string Email { get; init; } = string.Empty;
}