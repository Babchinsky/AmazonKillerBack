namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryDetailsDto : CategoryDto
{
    public Dictionary<string, List<string>> Filters { get; init; } = new();
}