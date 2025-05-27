using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;