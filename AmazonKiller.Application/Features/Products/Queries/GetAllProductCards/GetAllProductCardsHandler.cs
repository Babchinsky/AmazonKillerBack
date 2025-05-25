using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProductCards;

public class GetAllProductCardsHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetAllProductCardsQuery, List<ProductCardDto>>
{
    public async Task<List<ProductCardDto>> Handle(GetAllProductCardsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters)
            .ApplyPagination(q.Parameters);

        var entities = await query.ToListAsync(ct);
        return mapper.Map<List<ProductCardDto>>(entities);
    }
}