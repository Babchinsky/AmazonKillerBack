using AmazonKiller.Domain.Entities.Categories;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.Common;

public abstract class UpsertCategoryModel
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public CategoryStatus Status { get; init; }
    public Guid? ParentId { get; init; }
    public string? IconName { get; init; }
    public List<string>? PropertyKeys { get; init; }
    public IFormFile? Image { get; init; } // получаем файл отсюда
}