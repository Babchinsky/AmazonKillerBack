using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string? ProfilePicUrl { get; set; } 

    [Required]  
    [EmailAddress]  
    public string Email { get; set; } 

    [Required]  
    [PasswordPropertyText]  
    public string PasswordHash { get; set; }
    
    [Required]  
    public Role Role { get; set; }

    [Required]  
    [StringLength(20, MinimumLength = 1)]  
    public static string FirstName { get; set; }

    [Required]  
    [StringLength(20, MinimumLength = 1)] 
    public static string LastName { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public ICollection<Wishlist> WishlistsItems { get; set; } = new List<Wishlist>();
}