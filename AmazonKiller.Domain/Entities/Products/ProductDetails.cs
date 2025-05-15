using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Products;

public class ProductDetails
{
    public Guid Id { get; init; }

    [Required] [StringLength(50)] public required string FabricType { get; init; }

    [Required] [StringLength(100)] public required string CareInstructions { get; init; }

    [Required] [StringLength(50)] public required string Origin { get; init; }

    [Required] [StringLength(50)] public required string ClosureType { get; init; }

    [Required] public Brands Brand { get; init; }

    [Required] public Colors Color { get; init; }

    public ClothesSize? ClothesSize { get; init; }

    public ShoesSize? ShoesSize { get; init; }
}