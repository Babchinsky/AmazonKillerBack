using AmazonKiller.Application.DTOs.Filters;
using MediatR;

namespace AmazonKiller.Application.Features.Filters.Queries;

public record GetAvailableFiltersQuery(Guid CategoryId) : IRequest<AvailableFiltersDto>;