using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Commands.CreateCategory;

public record CreateCategoryCommand(string Name, Guid? ParentId) : IRequest<CategoryDto>;