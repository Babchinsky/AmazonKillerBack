using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Products;

public class ProductCardConfiguration : IEntityTypeConfiguration<ProductCard>
{
    public void Configure(EntityTypeBuilder<ProductCard> b)
    {
        b.Property(pc => pc.Price).HasPrecision(18, 2);
    }
}