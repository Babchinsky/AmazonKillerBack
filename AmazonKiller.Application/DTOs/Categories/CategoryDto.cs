using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Application.DTOs.Categories;

public record CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public Guid? ParentId { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public string? IconName { get; init; }
    public CategoryStatus Status { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}