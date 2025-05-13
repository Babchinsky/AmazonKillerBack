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

    public string? Description { get; set; }
    public string? ImageUrl { get; set; } // ссылка на изображение
    public string? IconName { get; set; } // только для категорий

    public ICollection<string> PropertyKeys { get; set; } = new List<string>(); // только для подкатегорий

    public ICollection<Product> Products { get; set; } = new List<Product>();
}