using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Products;

public class Category
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category> Children { get; set; } = new List<Category>();

    public CategoryStatus Status { get; set; } = CategoryStatus.Active;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}