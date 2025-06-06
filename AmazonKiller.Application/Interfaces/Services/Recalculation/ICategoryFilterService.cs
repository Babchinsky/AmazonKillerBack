namespace AmazonKiller.Application.Interfaces.Services.Recalculation;

public interface ICategoryFilterService
{
    Task RecalculateAsync(CancellationToken ct = default);
}