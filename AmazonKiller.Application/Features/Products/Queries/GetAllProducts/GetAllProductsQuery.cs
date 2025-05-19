using AmazonKiller.Application.DTOs.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Queries.GetAllProducts;

public record GetAllProductsQuery(
    string? SearchTerm,
    Guid? CategoryId,
    Dictionary<string, string>? Filters, // ← сюда передаём { "Brand": "Lenovo", "Screen size": "15.6" }
    decimal? MinPrice,
    decimal? MaxPrice,
    string? SortBy,
    bool SortDesc = false,
    int Page = 1,
    int PageSize = 20
) : IRequest<List<ProductDto>>;