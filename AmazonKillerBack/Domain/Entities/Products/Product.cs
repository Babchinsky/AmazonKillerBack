using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Domain.Entities.Products;

public class Product
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    public Rating Rating { get; set; }

    [Range(0, int.MaxValue)]
    public int ReviewsCount { get; set; }

    [Required]
    public List<string> ProductPics { get; set; } = [];

    [Required]
    public Guid DetailsId { get; set; }

    [Required]
    public ProductDetails Details { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }

    [Required]
    public ProductStatus Status { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    public bool InWishlist { get; set; }

    public bool InCartList { get; set; }
}