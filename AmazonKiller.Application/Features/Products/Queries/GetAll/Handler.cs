using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Queries.GetAll;

public class GetAllProductsHandler(IProductRepository repo, IMapper mapper)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsQueryable();

        if (!string.IsNullOrWhiteSpace(q.SearchTerm))
            query = query.Where(p => p.Name.Contains(q.SearchTerm));

        if (q.CategoryId.HasValue)
            query = query.Where(p => p.CategoryId == q.CategoryId);

        if (q.MinPrice.HasValue)
            query = query.Where(p => p.Price >= q.MinPrice);

        if (q.MaxPrice.HasValue)
            query = query.Where(p => p.Price <= q.MaxPrice);

        if (!string.IsNullOrEmpty(q.SortBy))
            query = (q.SortBy.ToLower(), q.SortDesc) switch
            {
                ("price", true) => query.OrderByDescending(p => p.Price),
                ("price", false) => query.OrderBy(p => p.Price),
                ("rating", true) => query.OrderByDescending(p => p.Rating),
                ("rating", false) => query.OrderBy(p => p.Rating),
                _ => query
            };

        query = query
            .Skip((q.Page - 1) * q.PageSize)
            .Take(q.PageSize);

        var list = await EntityFrameworkQueryableExtensions.ToListAsync(query, ct);
        return mapper.Map<List<ProductDto>>(list);
    }
}