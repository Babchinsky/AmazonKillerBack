using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Domain.Entities.Collections;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Collections.Public.Queries.GetAllCollections;

public class GetAllCollectionsHandler(
    ICollectionRepository repo,
    IMapper mapper
) : IRequestHandler<GetAllCollectionsQuery, PagedList<CollectionCardDto>>
{
    public async Task<PagedList<CollectionCardDto>> Handle(GetAllCollectionsQuery q, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking().Where(c => c.IsActive);

        query = query
            .ApplyFilters(q.SearchTerm, q.CategoryId, q.MinPrice, q.MaxPrice)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Collection, CollectionCardDto>(q.Parameters, mapper, ct);
    }
}