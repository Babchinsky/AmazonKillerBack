using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Domain.Entities.Products;

/// <summary>
/// Товар, отображаемый в каталоге / карточке продукта.
/// </summary>
public class Product
{
    /* ---------- PK & FK ---------- */

    public Guid Id { get; init; }

    public Guid CategoryId { get; init; }
    public Category Category { get; init; } = null!;

    /* ---------- General info ---------- */

    /// <summary> Уникальный артикул / штрих-код (до 60 симв.). </summary>
    public string Code { get; init; } = null!;

    /// <summary> Название товара (2–100 симв.). </summary>
    public string Name { get; init; } = null!;

    public decimal Price { get; init; } // Цена без учёта скидки
    public decimal? DiscountPercent { get; init; } // null ⇒ скидки нет, иначе 0–100 %
    public int SoldCount { get; set; } // NEW

    public int Quantity { get; init; } // Кол-во на складе
    public ProductStatus Status { get; init; } = ProductStatus.InStock;

    public List<string> ImageUrls { get; init; } = [];
    public List<ProductAttribute> Attributes { get; init; } = [];
    public List<ProductFeature> Features { get; init; } = [];

    /// <summary>Первое фото — «обложка».</summary>
    public string MainImageUrl => ImageUrls.FirstOrDefault() ?? "";

    /* ---------- Служебное ---------- */

    public decimal Rating { get; init; } // 0–5, вычисляется из отзывов
    public int ReviewsCount { get; init; }
    public bool InWishlist { get; init; }
    public bool InCartList { get; init; }

    /// <summary> Для конкуретного обновления (EF Core rowversion). </summary>
    public byte[] RowVersion { get; init; } = [];
}