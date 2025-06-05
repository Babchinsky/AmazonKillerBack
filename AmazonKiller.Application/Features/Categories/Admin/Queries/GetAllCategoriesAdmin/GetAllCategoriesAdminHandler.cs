using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Common;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Categories;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Admin.Queries.GetAllCategoriesAdmin;

public class GetAllCategoriesAdminHandler(ICategoryRepository repo, IMapper mapper)
    : IRequestHandler<GetAllCategoriesAdminQuery, PagedList<CategoryDto>>
{
    public async Task<PagedList<CategoryDto>> Handle(GetAllCategoriesAdminQuery request, CancellationToken ct)
    {
        var query = repo.Query()
            .ApplySorting(request.Parameters);

        return await query.ToPagedListAsync<Category, CategoryDto>(request.Parameters, mapper, ct);
    }
}