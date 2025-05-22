using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryHandler(
    ICategoryRepository repo,
    IFileStorage fileStorage,
    IMapper mapper
) : IRequestHandler<UpdateCategoryCommand, CategoryDto>
{
    public async Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken ct)
    {
        var c = await repo.GetByIdAsync(request.Id, ct)
                ?? throw new NotFoundException("Category not found");

        // 🔒 Проверка RowVersion
        c.RowVersion = Convert.FromBase64String(request.RowVersion);

        // 🔁 Загрузка нового изображения, если есть
        var newImageUrl = c.ImageUrl;
        if (request.Image is { Length: > 0 })
        {
            // Загрузить новое
            await using var stream = request.Image.OpenReadStream();
            var ext = Path.GetExtension(request.Image.FileName);
            newImageUrl = await fileStorage.SaveAsync(stream, ext, ct);
        }

        // ✏️ Обновление данных
        c.Name = request.Name;
        c.Status = request.Status;
        c.ParentId = request.ParentId;
        c.Description = request.Description;
        c.IconName = request.ParentId == null ? request.IconName : null;
        c.PropertyKeys = request.ParentId != null ? request.PropertyKeys ?? [] : [];
        c.ImageUrl = newImageUrl;

        // 🧪 Сохранение
        try
        {
            await repo.UpdateAsync(c, ct);
        }
        catch (Exception)
        {
            // Если был загружен новый файл, но сохранение упало — удалить файл
            if (request.Image != null && newImageUrl != c.ImageUrl)
                await fileStorage.DeleteAsync(newImageUrl!, ct);
            throw;
        }

        // 🧹 Удалить старое изображение (если новое есть и оно отличается)
        if (request.Image != null && c.ImageUrl != null && c.ImageUrl != newImageUrl)
            await fileStorage.DeleteAsync(c.ImageUrl, ct);

        return mapper.Map<CategoryDto>(c);
    }
}