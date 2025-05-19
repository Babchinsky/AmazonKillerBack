using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Domain.Entities.Categories;
using AmazonKiller.Domain.Entities.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    CategoryStatus Status,
    Guid? ParentId,
    string? Description,
    string? ImageUrl,
    string? IconName,
    List<string>? PropertyKeys
) : IRequest<CategoryDto>;