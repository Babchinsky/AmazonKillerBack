using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetRootCategories;

public record GetRootCategoriesQuery : IRequest<List<CategoryDto>>;