namespace AmazonKiller.Application.DTOs.Products;

public class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Rating { get; init; }
    public string Code { get; init; } = string.Empty;
    public int ReviewsCount { get; init; }
    public List<string> ImageUrls { get; init; } = [];
    public Guid CategoryId { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public int SoldCount { get; init; }
    public IReadOnlyCollection<ProductAttributeDto> Attributes { get; init; } = [];
    public IReadOnlyCollection<ProductFeatureDto> Features { get; init; } = [];
    public string RowVersion { get; init; } = string.Empty;
}