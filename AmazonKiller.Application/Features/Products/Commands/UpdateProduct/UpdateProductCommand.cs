using System.Text.Json;
using System.Text.Json.Serialization;
using AmazonKiller.Application.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest<ProductDto>
{
    public Guid Id { get; init; }
    public string RowVersion { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }

    public List<string> ExistingImageUrls { get; init; } = [];
    public List<IFormFile> NewImages { get; init; } = [];

    public string Attributes { get; init; } = "[]";
    public string Features { get; init; } = "[]";

    [JsonIgnore]
    public List<ProductAttributeDto> ParsedAttributes =>
        JsonSerializer.Deserialize<List<ProductAttributeDto>>(Attributes,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];

    [JsonIgnore]
    public List<ProductFeatureDto> ParsedFeatures =>
        JsonSerializer.Deserialize<List<ProductFeatureDto>>(Features,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
}