using System.Text.Json;
using System.Text.Json.Serialization;
using AmazonKiller.Application.DTOs.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.Common;

public abstract class UpsertProductModel
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public decimal Price { get; init; }
    public decimal? DiscountPercent { get; init; }
    public int Quantity { get; init; }
    public List<IFormFile> Images { get; init; } = [];

    public string Attributes { get; init; } = "[]";
    public string Features { get; init; } = "[]";

    [JsonIgnore]
    [BindNever]
    public List<ProductAttributeDto> ParsedAttributes => DeserializeSafe<ProductAttributeDto>(Attributes);

    [JsonIgnore]
    [BindNever]
    public List<ProductFeatureDto> ParsedFeatures => DeserializeSafe<ProductFeatureDto>(Features);

    private static List<T> DeserializeSafe<T>(string json)
    {
        return JsonSerializer.Deserialize<List<T>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
    }
}