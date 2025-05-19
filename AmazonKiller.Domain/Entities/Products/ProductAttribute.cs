namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Таблица ProductAttributes — «Property key / Attribute» в макете.
/// </summary>
public class ProductAttribute
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Key { get; init; } = null!;
    public string Value { get; init; } = null!;

    public Product Product { get; init; } = null!;
}