namespace AmazonKiller.Application.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public int Rating { get; set; } 
    
    public string Code { get; set; }
    
    public int ReviewsCount { get; set; }
    
    public List<string> ProductPics { get; set; } = [];
    
    public Guid DetailsId { get; set; }
    
    public Guid CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}