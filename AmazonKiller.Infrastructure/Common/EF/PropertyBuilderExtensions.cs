using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazonKiller.Infrastructure.Common.EF;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<decimal> UseMoneyPrecision(this PropertyBuilder<decimal> builder)
    {
        return builder.HasPrecision(18, 2);
    }

    public static PropertyBuilder<decimal?> UseMoneyPrecision(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(18, 2);
    }

    public static PropertyBuilder<decimal> UseRatingPrecision(this PropertyBuilder<decimal> builder)
    {
        return builder.HasPrecision(3, 2);
    }

    public static PropertyBuilder<decimal?> UseDiscountPrecision(this PropertyBuilder<decimal?> builder)
    {
        return builder.HasPrecision(5, 2);
    }
}