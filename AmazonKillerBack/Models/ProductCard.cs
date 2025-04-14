using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Models;

public class ProductCard
{
    [Required]
    public string ImageUrl { get; set; } 

    [Required]
    [StringLength(100, MinimumLength = 1)]  
    public string Name { get; set; } 

    [Range(0.01, double.MaxValue)]  
    public decimal Price { get; set; }

    public Rating Rating { get; set; }

    public bool Sale { get; set; }

    [Required]  
    public Guid ProductId { get; set; }

    [Range(0, int.MaxValue)] 
    public int ReviewsCount { get; set; }
}