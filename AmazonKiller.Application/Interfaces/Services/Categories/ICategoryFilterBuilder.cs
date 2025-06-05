namespace AmazonKiller.Application.Interfaces.Services.Categories;

public interface ICategoryFilterBuilder
{
    Task<Dictionary<string, List<string>>> BuildFiltersAsync(IEnumerable<Guid> categoryIds, CancellationToken ct);
}