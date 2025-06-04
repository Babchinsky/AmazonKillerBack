using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Categories;

public class CategoryRepository(AmazonDbContext db, IFileStorage fileStorage) : ICategoryRepository
{
    // ---- CRUD ---------------------------------------------------
    public Task<List<Category>> GetAllAsync(CancellationToken ct)
    {
        return db.Categories.AsNoTracking().ToListAsync(ct);
    }

    public Task<Category?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return db.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, ct);
    }

    public Task<bool> IsExistsAsync(Guid id, CancellationToken ct)
    {
        return db.Categories.AnyAsync(c => c.Id == id, ct);
    }

    public async Task AddAsync(Category c, CancellationToken ct)
    {
        db.Categories.Add(c);
        await db.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Category c, CancellationToken ct)
    {
        try
        {
            db.Categories.Update(c);
            await db.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new AppException(
                "The category was modified by another user. Please refresh the page and try again.");
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<Category> categories, CancellationToken ct)
    {
        var enumerable = categories.ToList();
        var imageUrls = enumerable
            .Select(c => c.ImageUrl)
            .Where(url => !string.IsNullOrWhiteSpace(url))
            .ToList();

        db.Categories.RemoveRange(enumerable);
        await db.SaveChangesAsync(ct);

        if (imageUrls.Count > 0) await fileStorage.DeleteBatchSafeAsync(imageUrls, ct);
    }

    public async Task<List<Guid>> GetAllActiveCategoryIdsAsync(CancellationToken ct = default)
    {
        return await db.Categories
            .Where(c => c.Status == CategoryStatus.Active)
            .Select(c => c.Id)
            .ToListAsync(ct);
    }

    public async Task UpdateWithCascadeStatusAsync(Category updatedCategory, CancellationToken ct)
    {
        // Проверка на изменение статуса
        var existing = await db.Categories
            .AsNoTracking()
            .Where(c => c.Id == updatedCategory.Id)
            .Select(c => c.Status)
            .FirstOrDefaultAsync(ct);

        if (existing == updatedCategory.Status)
        {
            // Только обновляем саму категорию
            db.Categories.Update(updatedCategory);
            await db.SaveChangesAsync(ct);
            return;
        }

        // Получаем всех потомков
        var allCategories = await db.Categories.ToListAsync(ct);
        var affectedIds = new List<Guid> { updatedCategory.Id };

        Collect(updatedCategory.Id);

        // Массовое обновление
        await db.Categories
            .Where(c => affectedIds.Contains(c.Id))
            .ExecuteUpdateAsync(set => set
                .SetProperty(c => c.Status, updatedCategory.Status), ct);
        return;

        void Collect(Guid parentId)
        {
            foreach (var child in allCategories.Where(c => c.ParentId == parentId))
            {
                affectedIds.Add(child.Id);
                Collect(child.Id);
            }
        }
    }
}