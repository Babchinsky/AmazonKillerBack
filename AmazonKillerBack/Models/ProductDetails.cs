using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Models;

public class ProductDetails
{
    [Required]
    [StringLength(50)]
    public string FabricType { get; set; } 

    [Required]
    [StringLength(100)]
    public string CareInstructions { get; set; } 

    [Required]
    [StringLength(50)]
    public string Origin { get; set; } 

    [Required]
    [StringLength(50)]
    public string ClosureType { get; set; } 
    
    [Required]
    public Brands Brand { get; set; }
    
    [Required]
    public Colors Color { get; set; } 
    
    public ClothesSize? ClothesSize { get; set; }
    
    public ShoesSize? ShoesSize { get; set; } 
}