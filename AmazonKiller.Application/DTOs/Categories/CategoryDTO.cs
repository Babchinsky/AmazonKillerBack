using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Application.DTOs.Categories;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? IconName { get; set; }
    public List<string>? PropertyKeys { get; set; }
    public CategoryStatus Status { get; set; }
}