using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Categories;
using AmazonKiller.Application.Features.Categories.Common;
using AmazonKiller.Application.Interfaces.Services.Categories;
using AmazonKiller.Domain.Entities.Categories;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Categories.Public.Queries.GetAllCategories;

public class GetAllCategoriesHandler(
    ICategoryQueryService categoryQueryService,
    IMapper mapper)
    : IRequestHandler<GetAllCategoriesQuery, PagedList<CategoryDto>>
{
    public async Task<PagedList<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken ct)
    {
        var query = await categoryQueryService.QueryVisibleCategoriesAsync(ct);
        query = query.ApplySorting(request.Parameters);
        return await query.ToPagedListAsync<Category, CategoryDto>(request.Parameters, mapper, ct);
    }
}