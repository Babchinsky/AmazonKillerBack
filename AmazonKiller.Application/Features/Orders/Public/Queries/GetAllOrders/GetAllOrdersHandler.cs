using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Orders;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Orders.Public.Queries.GetAllOrders;

public class GetAllOrdersHandler(IOrderRepository repo, IMapper mapper)
    : IRequestHandler<GetAllOrdersQuery, PagedList<OrderDto>>
{
    public async Task<PagedList<OrderDto>> Handle(GetAllOrdersQuery q, CancellationToken ct)
    {
        var query = repo.QueryWithIncludes()
            .AsNoTracking()
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Order, OrderDto>(q.Parameters, mapper, ct);
    }
}