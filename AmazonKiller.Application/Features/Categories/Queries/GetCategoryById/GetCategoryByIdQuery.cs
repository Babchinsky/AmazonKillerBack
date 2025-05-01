using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDto>;