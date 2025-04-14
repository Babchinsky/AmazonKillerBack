using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Models;

public class Product
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
    
    public Rating Rating { get; set; }

    // dotnet add package Ulid
    // public string Code { get; set; } = Ulid.NewUlid().ToString();
    
    [Range(0, int.MaxValue)]
    public int ReviewsCount { get; set; }

    [Required]
    public List<string> ProductPics { get; set; } = [];

    [Required]
    public ProductDetails Details { get; set; } = new ProductDetails();
    
    [Required]
    public Guid CategoryId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public ProductStatus Status { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    public bool inWishlist { get; set; }
    
    public bool inCartList { get; set; }
}
