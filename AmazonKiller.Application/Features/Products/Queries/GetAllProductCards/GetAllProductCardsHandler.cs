using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AmazonKiller.Domain.Entities.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProductCards;

public class GetAllProductCardsHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetAllProductCardsQuery, PagedList<ProductCardDto>>
{
    public async Task<PagedList<ProductCardDto>> Handle(GetAllProductCardsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Product, ProductCardDto>(q.Parameters, mapper, ct);
    }
}