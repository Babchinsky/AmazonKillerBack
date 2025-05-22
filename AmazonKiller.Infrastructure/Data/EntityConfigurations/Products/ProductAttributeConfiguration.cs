using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Products;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> b)
    {
        b.HasKey(x => x.Id);
        b.Property(x => x.Key).HasMaxLength(30).IsRequired();
        b.Property(x => x.Value).HasMaxLength(30).IsRequired();
        b.HasOne(x => x.Product)
            .WithMany(p => p.Attributes)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}