using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Common;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetAllProductCards;

public class GetAllActiveProductCardsHandler(
    IProductRepository productRepo,
    ICategoryRepository categoryRepo,
    ICategoryQueryService categoryQueryService,
    IMapper mapper)
    : IRequestHandler<GetAllActiveProductCardsQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetAllActiveProductCardsQuery q, CancellationToken ct)
    {
        var activeCategoryIds = await categoryRepo.GetAllActiveCategoryIdsAsync(ct);

        List<Guid>? filterCategoryIds = null;
        if (q.CategoryId.HasValue)
            filterCategoryIds = await categoryQueryService.GetDescendantCategoryIdsAsync(q.CategoryId.Value, ct);

        var query = productRepo.Queryable().AsNoTracking()
            .ApplyCategoryVisibilityFilter(activeCategoryIds)
            .ApplyFilters(q, filterCategoryIds)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Product, ProductCardDto>(q.Parameters, mapper, ct);
    }
}