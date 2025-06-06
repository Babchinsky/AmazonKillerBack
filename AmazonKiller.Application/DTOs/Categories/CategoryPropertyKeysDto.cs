namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryPropertyKeysDto
{
    public List<string> PropertyKeys { get; init; } = new();
    public List<string> ActivePropertyKeys { get; init; } = new();
}