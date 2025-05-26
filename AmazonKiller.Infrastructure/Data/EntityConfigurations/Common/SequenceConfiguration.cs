using AmazonKiller.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Common;

public class SequenceConfiguration : IEntityTypeConfiguration<Sequence>
{
    public void Configure(EntityTypeBuilder<Sequence> b)
    {
        b.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        b.Property(s => s.LastValue)
            .IsRequired();
    }
}