using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.DTOs.Products;

public class CreateProductRequest
{
    public string Name { get; init; } = "";
    public Guid CategoryId { get; init; }
    public decimal Price { get; init; }
    public decimal? Discount { get; init; } //  экран-2
    public int Quantity { get; init; }
    public List<IFormFile> Images { get; init; } = []; // до 10 шт.
    public List<AttributeDto> Attributes { get; init; } = [];
    public List<FeatureDto> Features { get; init; } = [];
}

public record AttributeDto(string Key, string Value);

public record FeatureDto(string Name, string Description);