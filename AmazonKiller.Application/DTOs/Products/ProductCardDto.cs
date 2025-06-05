namespace AmazonKiller.Application.DTOs.Products;

public record ProductCardDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string ImageUrl { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public string CategoryName { get; init; } = string.Empty;
    public decimal Rating { get; init; }
    public int ReviewsCount { get; init; }
    public int Quantity { get; init; }
    public decimal? DiscountPercent { get; init; } // e.g., 17.0 ⇒ "17% OFF"
}