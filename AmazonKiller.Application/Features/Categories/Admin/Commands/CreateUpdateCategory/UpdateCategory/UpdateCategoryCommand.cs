using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Commands.CreateUpdateCategory.UpdateCategory;

public class UpdateCategoryCommand : UpsertCategoryModel, IRequest<CategoryDto>
{
    public Guid Id { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}