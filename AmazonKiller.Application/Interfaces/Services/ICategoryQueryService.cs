using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Application.Interfaces.Services;

public interface ICategoryQueryService
{
    Task<Category?> GetByIdIfVisibleAsync(Guid id, bool isAdmin, CancellationToken ct);
    Task<bool> IsVisibleAsync(Guid id, bool isAdmin, CancellationToken ct);
    Task<List<Category>> GetTreeVisibleAsync(CancellationToken ct);
    Task<List<Category>> GetAllVisibleCategoriesAsync(bool isAdmin, CancellationToken ct);
}