using AmazonKiller.Domain.Entities.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Data.Configurations.Reviews;

public class ReviewContentConfiguration : IEntityTypeConfiguration<ReviewContent>
{
    public void Configure(EntityTypeBuilder<ReviewContent> b)
    {
        b.PrimitiveCollection(r => r.FilePaths);
    }
}