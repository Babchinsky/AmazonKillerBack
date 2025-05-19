using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Categories;

public class Category
{
    public Guid Id { get; init; }

    [Required]
    [StringLength(40, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;

    public Guid? ParentId { get; set; }
    public Category? Parent { get; init; }
    public ICollection<Category> Children { get; init; } = new List<Category>();

    public CategoryStatus Status { get; set; } = CategoryStatus.Active;

    public string? Description { get; set; }
    public string? ImageUrl { get; set; } // ссылка на изображение
    public string? IconName { get; set; } // только для категорий

    public ICollection<string> PropertyKeys { get; set; } = new List<string>(); // только для подкатегорий

    public ICollection<Product> Products { get; init; } = new List<Product>();
}