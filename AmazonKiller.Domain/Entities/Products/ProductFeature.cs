namespace AmazonKiller.Domain.Entities.Products;

public class ProductFeature
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
}