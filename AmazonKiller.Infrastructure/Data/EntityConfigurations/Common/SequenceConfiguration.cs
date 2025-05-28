using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Infrastructure.Common.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.EntityConfigurations.Common;

public class SequenceConfiguration : IEntityTypeConfiguration<Sequence>
{
    public void Configure(EntityTypeBuilder<Sequence> b)
    {
        b.HasKey(s => s.Name);

        b.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(ValidationConstants.NameMaxLength);

        b.Property(s => s.LastValue)
            .IsRequired();
    }
}