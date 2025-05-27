using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetCategoryById;

public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryDetailsDto>;