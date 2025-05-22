using AmazonKiller.Application.DTOs.Filters;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Queries.GetCategoryFilters;

public record GetCategoryFiltersQuery(Guid CategoryId) : IRequest<AvailableFiltersDto>;