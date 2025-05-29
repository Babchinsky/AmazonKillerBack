using AmazonKiller.Domain.Entities.Collections;
using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Categories;

public class Category : VersionedEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }
    public Category? Parent { get; init; }
    public ICollection<Category> Children { get; set; } = new List<Category>();

    public CategoryStatus Status { get; set; } = CategoryStatus.Active;

    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public string? IconName { get; set; }

    public ICollection<string> PropertyKeys { get; set; } = new List<string>();
    public ICollection<Collection> Collections { get; init; } = new List<Collection>();
    public ICollection<Product> Products { get; init; } = new List<Product>();
}