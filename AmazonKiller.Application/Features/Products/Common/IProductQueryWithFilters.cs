using AmazonKiller.Application.Common.Models;

namespace AmazonKiller.Application.Features.Products.Common;

public interface IProductQueryWithFilters
{
    string? SearchTerm { get; }
    Guid? CategoryId { get; }
    Dictionary<string, string>? Filters { get; }
    decimal? MinPrice { get; }
    decimal? MaxPrice { get; }
    QueryParameters Parameters { get; }
}