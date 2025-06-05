using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;

public class GetAllCategoriesAdminQuery : IRequest<PagedList<CategoryDto>>, ICategoriesQuery
{
    public QueryParameters Parameters { get; init; } = new();
}