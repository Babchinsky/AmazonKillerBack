using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Collections;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Public.Queries.GetAllCollections;

public class GetAllCollectionsQuery : IRequest<PagedList<CollectionCardDto>>
{
    public string? SearchTerm { get; init; }
    public Guid? CategoryId { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public QueryParameters Parameters { get; init; } = new();
}