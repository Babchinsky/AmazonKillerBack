using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Products;

public class Category
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(20, MinimumLength = 1)]  
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();
}