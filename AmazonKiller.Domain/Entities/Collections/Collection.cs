using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Domain.Entities.Common;

namespace AmazonKiller.Domain.Entities.Collections;

public class Collection : VersionedEntity
{
    public string Title { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; init; } = null!;

    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }

    /// <summary>
    /// Список заранее выбранных фильтров (Key–Value) для открытия каталога.
    /// </summary>
    public List<CollectionFilter> Filters { get; set; } = [];

    public bool IsActive { get; set; } = true;
}