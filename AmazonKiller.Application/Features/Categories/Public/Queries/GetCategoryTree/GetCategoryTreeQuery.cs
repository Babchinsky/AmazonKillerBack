using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryTree;

public record GetCategoryTreeQuery : IRequest<List<CategoryTreeDto>>;