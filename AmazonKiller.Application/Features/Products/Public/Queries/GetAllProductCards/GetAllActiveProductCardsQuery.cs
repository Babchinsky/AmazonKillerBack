using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Public.Queries.GetAllProductCards;

public class GetAllActiveProductCardsQuery : IRequest<PagedList<ProductCardDto>>, IProductQueryWithFilters
{
    public string? SearchTerm { get; init; }
    public Guid? CategoryId { get; init; }
    public Dictionary<string, string>? Filters { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}