using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Application.DTOs.Categories;

public class CategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public Guid? ParentId { get; init; }
    public string? Description { get; init; }
    public string? ImageUrl { get; init; }
    public string? IconName { get; init; }
    public CategoryStatus Status { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}