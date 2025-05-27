using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Common;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetAllProductCards;

public class GetAllActiveProductCardsHandler(
    IProductRepository productRepo,
    ICategoryRepository categoryRepo,
    IMapper mapper)
    : IRequestHandler<GetAllActiveProductCardsQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetAllActiveProductCardsQuery q, CancellationToken ct)
    {
        var activeCategoryIds = await categoryRepo.GetAllActiveCategoryIdsAsync(ct);

        var query = productRepo.Queryable().AsNoTracking()
            .ApplyCategoryVisibilityFilter(activeCategoryIds)
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Product, ProductCardDto>(q.Parameters, mapper, ct);
    }
}