using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Categories;

namespace AmazonKiller.Infrastructure.Services;

public class CategoryQueryService(
    ICategoryRepository repo) : ICategoryQueryService
{
    public async Task<Category?> GetByIdIfVisibleAsync(Guid id, bool isAdmin, CancellationToken ct)
    {
        var cat = await repo.GetByIdAsync(id, ct);
        if (cat is null) return null;

        if (isAdmin) return cat;

        var all = await repo.GetAllAsync(ct);
        var visible = GetActiveIdsRecursive(all);
        return visible.Contains(cat.Id) ? cat : null;
    }

    public async Task<bool> IsVisibleAsync(Guid id, bool isAdmin, CancellationToken ct)
    {
        var cat = await repo.GetByIdAsync(id, ct);
        if (cat is null) return false;

        if (isAdmin) return true;

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

    public async Task<List<Category>> GetAllVisibleCategoriesAsync(bool isAdmin, CancellationToken ct)
    {
        var all = await repo.GetAllAsync(ct);

        if (isAdmin)
            return all;

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
}