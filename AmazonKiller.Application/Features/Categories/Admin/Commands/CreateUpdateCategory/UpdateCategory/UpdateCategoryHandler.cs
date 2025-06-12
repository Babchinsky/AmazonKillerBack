using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryHandler(
    ICategoryRepository repo,
    ICategoryQueryService categoryQueryService,
    IFileStorage fileStorage
) : IRequestHandler<UpdateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken ct)
    {
        var category = await repo.GetByIdAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");

        // 🔒 Проверка RowVersion
        category.RowVersion = Convert.FromBase64String(request.RowVersion);

        // 🧠 Получаем все связанные категории (текущую и потомков)
        var allCategoryIds = await categoryQueryService.GetDescendantCategoryIdsAsync(request.Id, ct);
        allCategoryIds.Add(request.Id);

        var allCategories = await repo.Query()
            .Where(c => allCategoryIds.Contains(c.Id))
            .ToListAsync(ct);

        var allPropertyKeys = allCategories
            .SelectMany(c => c.PropertyKeys)
            .ToHashSet();

        if (request.ActivePropertyKeys is not null)
        {
            var invalidKeys = request.ActivePropertyKeys.Where(k => !allPropertyKeys.Contains(k)).ToList();
            if (invalidKeys.Count > 0)
                throw new AppException($"Invalid property keys: {string.Join(", ", invalidKeys)}");
        }

        // 🔁 Сохраняем старый URL для возможного удаления
        var oldImageUrl = category.ImageUrl;

        // 📥 Загрузка нового изображения, если есть
        var newImageUrl = oldImageUrl;
        if (request.Image is { Length: > 0 })
        {
            await using var stream = request.Image.OpenReadStream();
            var ext = Path.GetExtension(request.Image.FileName);
            newImageUrl = await fileStorage.SaveAsync(stream, ext, ct);
        }

        // ✏️ Обновление полей
        category.Name = request.Name;
        category.Status = request.Status;
        category.ParentId = request.ParentId;
        category.Description = request.Description;
        category.IconName = request.ParentId == null ? request.IconName : null;
        category.ActivePropertyKeys = request.ActivePropertyKeys ?? [];
        category.ImageUrl = newImageUrl;

        var imageChanged = request.Image != null && newImageUrl != oldImageUrl;
        var updateSucceeded = false;

        try
        {
            await repo.UpdateWithCascadeStatusAsync(category, ct);
            updateSucceeded = true;
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FOREIGN KEY") == true)
        {
            throw new AppException("Invalid parent category. The specified ParentId does not exist or is invalid.");
        }
        catch (Exception)
        {
            throw new AppException("An unexpected error occurred while updating the category.");
        }
        finally
        {
            if (!updateSucceeded && imageChanged)
                await fileStorage.DeleteAsync(newImageUrl!, ct);
        }

        if (imageChanged && updateSucceeded && oldImageUrl != null)
            await fileStorage.DeleteAsync(oldImageUrl, ct);

        return category.Id;
    }
}