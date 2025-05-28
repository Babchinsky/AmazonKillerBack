using AmazonKiller.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Common.EF;

public static class ConcurrencyExtensions
{
    public static void ConfigureRowVersion<TEntity>(this EntityTypeBuilder<TEntity> builder)
        where TEntity : VersionedEntity
    {
        builder.Property(x => x.RowVersion)
            .IsRowVersion()
            .IsConcurrencyToken()
            .ValueGeneratedOnAddOrUpdate();
    }
}