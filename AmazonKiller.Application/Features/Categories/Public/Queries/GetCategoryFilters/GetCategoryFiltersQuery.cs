using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryFilters;

public record GetCategoryFiltersQuery(Guid CategoryId) : IRequest<CategoryFiltersDto>;