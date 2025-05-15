using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Sales;
using NUlid;

namespace AmazonKiller.Domain.Entities.Products;

public class Product
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Code { get; init; } = Ulid.NewUlid().ToString(); // ULID unique

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; init; } = string.Empty;

    public Rating Rating { get; init; } = Rating.Five;
    public int ReviewsCount { get; init; }
    public List<string> ProductPics { get; init; } = []; // stored as JSON

    [Required] public Guid DetailsId { get; init; }
    [Required] public ProductDetails Details { get; init; } = null!;

    [Required] public Guid CategoryId { get; init; }
    [Range(0.01, double.MaxValue)] public decimal Price { get; init; }
    public int Quantity { get; init; }
    public ProductStatus Status { get; init; } = ProductStatus.InStock;
    public bool InWishlist { get; init; }
    public bool InCartList { get; init; }
    public Sale? Sale { get; set; }
    [Timestamp] public byte[] RowVersion { get; init; } = []; // optimistic concurrency
}