namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Таблица ProductFeatures — блок «About product» в макете.
/// </summary>
public class ProductFeature
{
    public Guid Id { get; init; }
    public Guid ProductId { get; init; }
    public string Name { get; init; } = null!;
    public string Description { get; init; } = null!;

    public Product Product { get; init; } = null!;
}