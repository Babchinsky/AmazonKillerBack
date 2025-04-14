using System.ComponentModel.DataAnnotations;
using AmazonKillerBack.Domain.Entities.Products;

namespace AmazonKillerBack.Domain.Entities.Users;

public class Wishlist
{
    public Guid Id { get; set; }  
    
    [Required]
    public Guid UserId { get; set; } 
    
    public ICollection<ProductCard> Products { get; set; } = new List<ProductCard>();
}