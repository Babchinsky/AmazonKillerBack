namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Таблица ProductAttributes — «Property key / Attribute» в макете.
/// </summary>
public class ProductAttribute
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Key { get; set; } = null!;
    public string Value { get; set; } = null!;

    public Product Product { get; set; } = null!;
}