namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Таблица ProductFeatures — блок «About product» в макете.
/// </summary>
public class ProductFeature
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public Product Product { get; set; } = null!;
}