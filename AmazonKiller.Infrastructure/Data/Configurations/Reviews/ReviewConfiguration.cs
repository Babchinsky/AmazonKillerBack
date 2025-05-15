using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Reviews;

public class ReviewConfiguration : IEntityTypeConfiguration<Domain.Entities.Reviews.Review>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Reviews.Review> b)
    {
        b.Property(r => r.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd();

        b.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(r => r.Content)
            .WithOne()
            .HasForeignKey<Domain.Entities.Reviews.Review>(r => r.ContentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}