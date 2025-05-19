using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler(IProductRepository repo)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking();

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
                ("soldcount", true) => query.OrderByDescending(p => p.SoldCount),
                ("soldcount", false) => query.OrderBy(p => p.SoldCount),
                _ => query
            };

        if (q.Filters is not null)
        {
            foreach (var (key, val) in q.Filters)
            {
                query = query.Where(p =>
                    p.Attributes.Any(a => a.Key == key && a.Value == val));
            }
        }

        return await query
            .Skip((q.Page - 1) * q.PageSize)
            .Take(q.PageSize)
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Rating = (int)p.Rating,
                ReviewsCount = p.ReviewsCount,
                ProductPics = p.ProductPics,
                CategoryId = p.CategoryId,
                Price = p.Price,
                Quantity = p.Quantity,
                SoldCount = p.SoldCount,
                RowVersion = Convert.ToBase64String(p.RowVersion),
                Attributes = p.Attributes.Select(a => new ProductAttributeDto(a.Key, a.Value)).ToList(),
                Features = p.Features.Select(f => new ProductFeatureDto(f.Name, f.Description)).ToList()
            })
            .ToListAsync(ct);
    }
}