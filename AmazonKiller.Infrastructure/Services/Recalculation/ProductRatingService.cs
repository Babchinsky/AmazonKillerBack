using AmazonKiller.Application.Interfaces.Services.Recalculation;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services.Recalculation;

public sealed class ProductRatingService(AmazonDbContext db) : IProductRatingService
{
    public async Task RecalculateAsync(CancellationToken ct = default)
    {
        // 1. агрегируем отзывы
        var stats = await db.Reviews
            .GroupBy(r => r.ProductId)
            .Select(g => new
            {
                g.Key,
                ReviewsCnt = g.Count(),
                AvgRating = Math.Round(g.Average(r => r.Rating), 2)
            })
            .ToDictionaryAsync(x => x.Key, ct);

        // 2. обновляем продукты затрагиваемые статистикой
        var products = await db.Products
            .Where(p => stats.Keys.Contains(p.Id)) // меньше данных — быстрее
            .ToListAsync(ct);

        foreach (var p in products)
        {
            var s = stats[p.Id];
            p.Rating = s.AvgRating;
            p.ReviewsCount = s.ReviewsCnt;
        }

        // 3. выставляем 0/0 тем, у кого отзывов нет (опционально)
        var withoutReviews = await db.Products
            .Where(p => !stats.Keys.Contains(p.Id) && (p.Rating != 0 || p.ReviewsCount != 0))
            .ToListAsync(ct);

        foreach (var p in withoutReviews)
        {
            p.Rating = 0;
            p.ReviewsCount = 0;
        }

        await db.SaveChangesAsync(ct);
    }
}