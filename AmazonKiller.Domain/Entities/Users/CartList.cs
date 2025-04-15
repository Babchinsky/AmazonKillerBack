using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class CartList
{
    public Guid Id { get; set; }  
    
    [Required]
    public Guid UserId { get; set; } 
    
    [Required]
    public ICollection<ProductCard> Products { get; set; } = new List<ProductCard>();
    
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Range(1, int.MaxValue)]
    public int Price { get; set; }
}