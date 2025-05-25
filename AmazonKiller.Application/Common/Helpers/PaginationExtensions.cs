using AmazonKiller.Application.Common.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Common.Helpers;

public static class PaginationExtensions
{
    public static async Task<PagedList<TDto>> ToPagedListAsync<TEntity, TDto>(
        this IQueryable<TEntity> query,
        QueryParameters parameters,
        IMapper mapper,
        CancellationToken ct)
    {
        var totalCount = await query.CountAsync(ct);

        var items = await query
            .Skip((parameters.Page - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync(ct);

        var dtoItems = mapper.Map<List<TDto>>(items);

        return new PagedList<TDto>
        {
            Items = dtoItems,
            Page = parameters.Page,
            PageSize = parameters.PageSize,
            TotalCount = totalCount
        };
    }
}