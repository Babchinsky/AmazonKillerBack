using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Application.Interfaces.Services.Categories;

public interface ICategoryQueryService
{
    Task<Category?> GetByIdIfVisibleAsync(Guid id, CancellationToken ct);
    Task<bool> IsVisibleAsync(Guid id, CancellationToken ct);
    Task<List<Category>> GetTreeVisibleAsync(CancellationToken ct);
    Task<List<Category>> GetAllVisibleCategoriesAsync(CancellationToken ct);
    Task<List<Guid>> GetDescendantCategoryIdsAsync(Guid parentId, CancellationToken ct = default);
    Task<IQueryable<Category>> QueryVisibleCategoriesAsync(CancellationToken ct);
}