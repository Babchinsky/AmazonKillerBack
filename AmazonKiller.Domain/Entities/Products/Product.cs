using System.ComponentModel.DataAnnotations;
using NUlid;

namespace AmazonKiller.Domain.Entities.Products;

public class Product
{
    public Guid   Id   { get; init; } = Guid.NewGuid();
    public string Code { get; init; } = Ulid.NewUlid().ToString();   // ULID unique

    [Required, StringLength(100, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;

    public Rating Rating         { get; set; } = Rating.Five;
    public int    ReviewsCount   { get; set; }
    public List<string> ProductPics { get; set; } = new();          // stored as JSON

    [Required] public Guid            DetailsId { get; set; }
    [Required] public ProductDetails  Details   { get; set; } = null!;

    [Required] public Guid            CategoryId { get; set; }
    [Range(0.01, double.MaxValue)] public decimal Price    { get; set; }
    public int    Quantity   { get; set; }
    public ProductStatus Status { get; set; } = ProductStatus.InStock;
    public bool   InWishlist { get; set; }
    public bool   InCartList { get; set; }
    [Timestamp]   public byte[] RowVersion { get; set; } = [];      // optimistic concurrency
}
