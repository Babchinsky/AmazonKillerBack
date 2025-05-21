using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsHandler(IProductRepository repo)
    : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetAllProductsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters)
            .ApplyPagination(q.Parameters);

        return await query
            .Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Code = p.Code,
                Rating = (int)p.Rating,
                ReviewsCount = p.ReviewsCount,
                ImageUrls = p.ImageUrls,
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