namespace AmazonKiller.Application.Interfaces.Services.Recalculation;

public interface ICategoryFilterService
{
    Task RecalculateAsync(bool resetActive = false, CancellationToken ct = default);
}