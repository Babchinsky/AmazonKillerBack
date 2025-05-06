namespace AmazonKiller.Domain.Entities.Products;

public class ProductAttribute
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Key { get; set; } = "";
    public string Value { get; set; } = "";
}