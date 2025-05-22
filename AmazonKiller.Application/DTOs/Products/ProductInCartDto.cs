namespace AmazonKiller.Application.DTOs.Products;

public class ProductInCartDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public decimal Total => Price * Quantity;
}