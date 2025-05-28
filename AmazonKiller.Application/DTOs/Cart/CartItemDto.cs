namespace AmazonKiller.Application.DTOs.Cart;

public record CartItemDto
{
    public Guid ProductId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string ImageUrl { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public decimal Total => Price * Quantity;
}