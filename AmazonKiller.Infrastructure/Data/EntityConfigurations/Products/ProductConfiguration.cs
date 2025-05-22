using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> e)
    {
        e.HasIndex(p => p.Code).IsUnique();

        e.PrimitiveCollection(p => p.ImageUrls);

        e.Property(p => p.Price).HasPrecision(18, 2);
        e.Property(p => p.DiscountPercent).HasPrecision(5, 2);

        e.Property(p => p.AverageRating).HasPrecision(3, 2);
        e.Property(p => p.RowVersion).IsRowVersion().IsConcurrencyToken();
    }
}