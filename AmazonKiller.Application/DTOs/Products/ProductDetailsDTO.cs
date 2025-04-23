namespace AmazonKiller.Application.DTOs.Products;

public class ProductDetailsDto
{
    public Guid Id { get; set; }
    
    public string FabricType { get; set; } 
    
    public string CareInstructions { get; set; } 
    
    public string Origin { get; set; } 
    
    public string ClosureType { get; set; } 
    
    public string Brand { get; set; } 
    
    public string Color { get; set; } 
    
    public string? ClothesSize { get; set; } 
    
    public int? ShoesSize { get; set; } 
}