using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryByIdAdmin;

public record GetCategoryByIdAdminQuery(Guid Id) : IRequest<CategoryDetailsDto>;