using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Products;

public class ProductDetails
{
    public Guid Id { get; set; }

    [Required] [StringLength(50)] public required string FabricType { get; set; }

    [Required] [StringLength(100)] public required string CareInstructions { get; set; }

    [Required] [StringLength(50)] public required string Origin { get; set; }

    [Required] [StringLength(50)] public required string ClosureType { get; set; }

    [Required] public Brands Brand { get; set; }

    [Required] public Colors Color { get; set; }

    public ClothesSize? ClothesSize { get; set; }

    public ShoesSize? ShoesSize { get; set; }
}