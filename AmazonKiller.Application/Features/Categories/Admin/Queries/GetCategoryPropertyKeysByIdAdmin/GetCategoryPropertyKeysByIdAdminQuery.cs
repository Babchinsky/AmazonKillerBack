using AmazonKiller.Application.DTOs.Categories;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetCategoryPropertyKeysByIdAdmin;

public record GetCategoryPropertyKeysByIdAdminQuery(Guid CategoryId) : IRequest<CategoryPropertyKeysDto>;