using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryPropertyKeysByIdAdmin;

public class GetCategoryPropertyKeysByIdAdminHandler(
    ICategoryQueryService categoryQueryService,
    ICategoryRepository categoryRepo
) : IRequestHandler<GetCategoryPropertyKeysByIdAdminQuery, CategoryPropertyKeysDto>
{
    public async Task<CategoryPropertyKeysDto> Handle(GetCategoryPropertyKeysByIdAdminQuery q, CancellationToken ct)
    {
        // Получаем категорию
        var category = await categoryRepo.GetByIdAsync(q.CategoryId, ct)
                       ?? throw new NotFoundException("Category not found");

        // Получаем всех потомков
        var allCategoryIds = await categoryQueryService.GetDescendantCategoryIdsAsync(q.CategoryId, ct);
        allCategoryIds.Add(q.CategoryId);

        // Загружаем их из БД
        var allCategories = await categoryRepo.Query()
            .Where(c => allCategoryIds.Contains(c.Id))
            .ToListAsync(ct);

        // Собираем все PropertyKeys
        var propertyKeys = allCategories
            .SelectMany(c => c.PropertyKeys)
            .Distinct()
            .ToList();

        return new CategoryPropertyKeysDto
        {
            PropertyKeys = propertyKeys,
            ActivePropertyKeys = category.ActivePropertyKeys.ToList()
        };
    }
}