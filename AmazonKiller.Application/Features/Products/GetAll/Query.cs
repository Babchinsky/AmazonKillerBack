using AmazonKiller.Application.DTOs;
using MediatR;

namespace AmazonKiller.Application.Features.Products.GetAll;

public record GetAllProductsQuery(
    string? SearchTerm,
    Guid? CategoryId,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? SortBy,
    bool SortDesc = false,
    int Page = 1,
    int PageSize = 20
) : IRequest<List<ProductDto>>;