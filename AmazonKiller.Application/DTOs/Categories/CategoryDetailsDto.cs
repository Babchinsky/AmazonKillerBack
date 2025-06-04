using System.Text.Json.Serialization;

namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryDetailsDto : CategoryDto
{
    [JsonPropertyOrder(100)] public Dictionary<string, List<string>> Filters { get; init; } = new();
}