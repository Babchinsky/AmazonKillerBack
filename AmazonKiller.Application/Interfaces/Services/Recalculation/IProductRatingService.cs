namespace AmazonKiller.Application.Interfaces.Services.Recalculation;

public interface IProductRatingService
{
    Task RecalculateAsync(CancellationToken ct = default);
}