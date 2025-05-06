using System.ComponentModel.DataAnnotations;
using AmazonKiller.Application.DTOs.Products;

namespace AmazonKiller.WebApi.Requests;

public class CreateProductRequest
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; init; } = "";

    [Required] public Guid CategoryId { get; init; }
    [Required] public Guid DetailsId { get; init; }

    [Range(0.01, 1_000_000)] public decimal Price { get; init; }
    [Range(0, int.MaxValue)] public int Quantity { get; init; }

    [Range(0.01, 1_000_000)] public decimal? Discount { get; init; }

    [MaxLength(10)] public List<IFormFile> Images { get; init; } = [];

    public List<AttributeDto> Attributes { get; init; } = [];
    public List<FeatureDto> Features { get; init; } = [];
}