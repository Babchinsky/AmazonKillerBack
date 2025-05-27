using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Common;
using AmazonKiller.Application.Features.Products.Public.Queries.GetAllProductCards;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Admin.Queries.GetAllProductsAdmin;

public class GetAllProductsAdminHandler(
    IProductRepository productRepo,
    IMapper mapper)
    : IRequestHandler<GetAllProductsAdminQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetAllProductsAdminQuery q, CancellationToken ct)
    {
        var query = productRepo.Queryable().AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Product, ProductCardDto>(q.Parameters, mapper, ct);
    }
}