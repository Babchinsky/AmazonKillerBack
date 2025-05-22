using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProductCards;

public class GetAllProductCardsHandler(IProductRepository repo)
    : IRequestHandler<GetAllProductCardsQuery, List<ProductCardDto>>
{
    public async Task<List<ProductCardDto>> Handle(GetAllProductCardsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters)
            .ApplyPagination(q.Parameters);

        return await query
            .Select(p => new ProductCardDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.MainImageUrl,
                Rating = p.AverageRating,
                ReviewsCount = p.Reviews.Count,
                DiscountPercent = p.DiscountPercent
            })
            .ToListAsync(ct);
    }
}