using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Domain.Entities.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(
    string Name,
    Guid? ParentId,
    string? Description,
    string? ImageUrl,
    string? IconName,
    List<string>? PropertyKeys,
    CategoryStatus Status
) : IRequest<CategoryDto>;