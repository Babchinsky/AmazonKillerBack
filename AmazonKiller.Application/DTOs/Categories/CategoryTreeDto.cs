namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryTreeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public List<CategoryTreeDto> Children { get; init; } = [];
}