namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryFiltersDto
{
    public Dictionary<string, List<string>> Filters { get; init; } = new();
}