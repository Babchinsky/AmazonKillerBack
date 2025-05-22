using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProductCards;

public class GetAllProductCardsQuery : IRequest<List<ProductCardDto>>
{
    public string? SearchTerm { get; init; }
    public Guid? CategoryId { get; init; }
    public Dictionary<string, string>? Filters { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}