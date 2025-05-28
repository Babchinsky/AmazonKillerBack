using AmazonKiller.Domain.Entities.Reviews;
using AmazonKiller.Infrastructure.Common.EF;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Reviews;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> b)
    {
        b.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        b.Property(r => r.Rating).UseRatingPrecision();
        b.Property(r => r.Article).HasMaxLength(ValidationConstants.ArticleMaxLength).IsRequired();
        b.Property(r => r.Message).HasMaxLength(ValidationConstants.MessageMaxLength).IsRequired();

        b.HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(r => r.Product)
            .WithMany(p => p.Reviews)
            .HasForeignKey(r => r.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        b.PrimitiveCollection(r => r.ImageUrls);
        b.PrimitiveCollection(r => r.Tags);

        b.ConfigureRowVersion();
    }
}