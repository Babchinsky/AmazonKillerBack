using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Products;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> e)
    {
        e.HasIndex(p => p.Code).IsUnique();
        e.PrimitiveCollection(p => p.ProductPics);
        e.Property(p => p.Price).HasPrecision(18, 2);
        e.Property(p => p.RowVersion).IsRowVersion();
    }
}