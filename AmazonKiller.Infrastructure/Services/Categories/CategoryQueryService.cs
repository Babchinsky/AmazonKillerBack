using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Infrastructure.Services.Categories;

public class CategoryQueryService(
    ICategoryRepository repo) : ICategoryQueryService
{
    public async Task<Category?> GetByIdIfVisibleAsync(Guid id, CancellationToken ct)
    {
        var cat = await repo.GetByIdAsync(id, ct);
        if (cat is null) return null;

        var all = await repo.GetAllAsync(ct);
        var visible = GetActiveIdsRecursive(all);
        return visible.Contains(cat.Id) ? cat : null;
    }

    public async Task<bool> IsVisibleAsync(Guid id, CancellationToken ct)
    {
        var cat = await repo.GetByIdAsync(id, ct);
        if (cat is null) return false;

        var all = await repo.GetAllAsync(ct);
        var visible = GetActiveIdsRecursive(all);
        return visible.Contains(cat.Id);
    }

    public async Task<List<Category>> GetTreeVisibleAsync(CancellationToken ct)
    {
        var all = await repo.GetAllAsync(ct);
        var visibleIds = GetActiveIdsRecursive(all);
        return all
            .Where(c => c.ParentId == null && visibleIds.Contains(c.Id))
            .Select(c => BuildTree(c, all, visibleIds))
            .ToList();

        static Category BuildTree(Category root, List<Category> all, HashSet<Guid> visibleIds)
        {
            root.Children = all
                .Where(c => c.ParentId == root.Id && visibleIds.Contains(c.Id))
                .Select(c => BuildTree(c, all, visibleIds))
                .ToList();
            return root;
        }
    }

    public async Task<List<Category>> GetAllVisibleCategoriesAsync(CancellationToken ct)
    {
        var all = await repo.GetAllAsync(ct);

        var visibleIds = GetActiveIdsRecursive(all);

        return all.Where(c => visibleIds.Contains(c.Id)).ToList();
    }

    private static HashSet<Guid> GetActiveIdsRecursive(List<Category> all)
    {
        var allowed = new HashSet<Guid>();

        foreach (var c in all.Where(x => x.ParentId == null && x.Status == CategoryStatus.Active))
            Collect(c.Id);

        return allowed;

        void Collect(Guid id)
        {
            allowed.Add(id);
            foreach (var c in all.Where(x => x.ParentId == id && x.Status == CategoryStatus.Active))
                Collect(c.Id);
        }
    }

    public async Task<List<Guid>> GetDescendantCategoryIdsAsync(Guid parentId, CancellationToken ct = default)
    {
        var all = await repo.GetAllAsync(ct);
        var ids = new List<Guid> { parentId };

        Collect(parentId);
        return ids;

        void Collect(Guid id)
        {
            foreach (var child in all.Where(c => c.ParentId == id))
            {
                ids.Add(child.Id);
                Collect(child.Id);
            }
        }
    }

    public async Task<IQueryable<Category>> QueryVisibleCategoriesAsync(CancellationToken ct)
    {
        var all = await repo.GetAllAsync(ct);
        var visibleIds = GetActiveIdsRecursive(all);

        return repo.Query().Where(c => visibleIds.Contains(c.Id));
    }
}