using AmazonKiller.Domain.Entities.Sales;

namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Товар, отображаемый в каталоге / карточке продукта.
/// </summary>
public class Product
{
    /* ---------- PK & FK ---------- */

    public Guid Id { get; init; }

    public Guid CategoryId { get; set; }
    public Category Category { get; init; } = null!;

    /* ---------- General info ---------- */

    /// <summary> Уникальный артикул / штрих-код (до 60 симв.). </summary>
    public string Code { get; init; } = null!;

    /// <summary> Название товара (2–100 симв.). </summary>
    public string Name { get; set; } = null!;

    public decimal Price { get; set; } // Цена без учёта скидки
    public decimal? DiscountPct { get; init; } // null ⇒ скидки нет, иначе 0–100 %
    public Sale? Sale { get; init; } // навигация односторонняя
    public int SoldCount { get; set; } // NEW

    public int Quantity { get; set; } // Кол-во на складе
    public ProductStatus Status { get; init; } = ProductStatus.InStock;

    public List<string> ProductPics { get; init; } = [];
    public ICollection<ProductAttribute> Attributes { get; init; } = new List<ProductAttribute>();
    public ICollection<ProductFeature> Features { get; init; } = new List<ProductFeature>();

    /// <summary>Первое фото — «обложка».</summary>
    public string MainImageUrl => ProductPics.FirstOrDefault() ?? "";

    /* ---------- Служебное ---------- */

    public Rating Rating { get; init; } // 0–5, вычисляется из отзывов
    public int ReviewsCount { get; init; }
    public bool InWishlist { get; init; }
    public bool InCartList { get; init; }

    /// <summary> Для конкуретного обновления (EF Core rowversion). </summary>
    public byte[] RowVersion { get; init; } = [];
}