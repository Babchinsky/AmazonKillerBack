namespace AmazonKiller.Application.DTOs.Products;

public record ProductFeatureDto
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}