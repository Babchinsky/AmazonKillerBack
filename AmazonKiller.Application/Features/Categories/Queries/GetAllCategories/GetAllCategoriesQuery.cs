using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetAllCategories;

public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;