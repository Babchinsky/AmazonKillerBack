using AmazonKiller.Application.DTOs.Products;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AmazonKiller.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// Команда создания товара; приходит из WebAPI-слоя через AutoMapper.
/// </summary>
public record CreateProductCommand : IRequest<Guid>
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public decimal Price { get; init; }
    public decimal? DiscountPct { get; init; }
    public int Quantity { get; init; }
    public List<IFormFile> Images { get; init; } = [];

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Attributes { get; init; } = "[]";

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Features { get; init; } = "[]";

    [JsonIgnore]
    public List<ProductAttributeDto> ParsedAttributes
    {
        get
        {
            try
            {
                return JsonSerializer.Deserialize<List<ProductAttributeDto>>(Attributes,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
            }
            catch
            {
                // Здесь можно добавить логгирование
                return [];
            }
        }
    }

    [JsonIgnore]
    public List<ProductFeatureDto> ParsedFeatures
    {
        get
        {
            try
            {
                return JsonSerializer.Deserialize<List<ProductFeatureDto>>(Features,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
            }
            catch
            {
                // Здесь можно добавить логгирование
                return [];
            }
        }
    }
}