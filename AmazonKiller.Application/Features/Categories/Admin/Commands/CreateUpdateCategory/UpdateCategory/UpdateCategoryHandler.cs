using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryHandler(
    ICategoryRepository repo,
    IFileStorage fileStorage,
    IMapper mapper
) : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken ct)
    {
        var category = await repo.GetByIdAsync(request.Id, ct)
                       ?? throw new NotFoundException("Category not found");

        // 🔒 Проверка RowVersion
        category.RowVersion = Convert.FromBase64String(request.RowVersion);

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
        category.PropertyKeys = request.ParentId != null ? request.PropertyKeys ?? [] : [];
        category.ImageUrl = newImageUrl;

        try
        {
            await repo.UpdateWithCascadeStatusAsync(category, ct);
        }
        catch (Exception)
        {
            // если упало — откатываем новый файл
            if (request.Image != null && newImageUrl != oldImageUrl)
                await fileStorage.DeleteAsync(newImageUrl!, ct);
            throw;
        }

        // 🧹 Удаление старого изображения, если оно изменилось
        if (request.Image != null && oldImageUrl != null && oldImageUrl != newImageUrl)
            await fileStorage.DeleteAsync(oldImageUrl, ct);

        return mapper.Map<CategoryDto>(category);
    }
}