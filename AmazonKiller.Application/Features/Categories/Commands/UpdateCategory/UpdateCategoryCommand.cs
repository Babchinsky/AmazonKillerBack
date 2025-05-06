using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Domain.Entities.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(
    Guid Id,
    string Name,
    CategoryStatus Status,
    Guid? ParentId) : IRequest<CategoryDto>;