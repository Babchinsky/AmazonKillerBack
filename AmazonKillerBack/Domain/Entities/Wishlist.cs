using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Domain.Entities;

public class Wishlist
{
    public Guid Id { get; set; }  
    
    [Required]
    public Guid UserId { get; set; } 
    
    public ICollection<ProductCard> Products { get; set; } = new List<ProductCard>();
}