namespace AmazonKiller.Application.DTOs.Products;

public record ProductAttributeDto
{
    public string Key { get; init; } = string.Empty;
    public string Value { get; init; } = string.Empty;
}