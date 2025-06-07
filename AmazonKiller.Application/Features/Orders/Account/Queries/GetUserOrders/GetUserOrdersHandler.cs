using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Orders;
using AmazonKiller.Application.Features.Orders.Common;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Orders;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Orders.Account.Queries.GetUserOrders;

public class GetUserOrdersHandler(
    IOrderRepository repo,
    IMapper mapper,
    ICurrentUserService currentUser,
    IAccountRepository accountRepo)
    : IRequestHandler<GetUserOrdersQuery, PagedList<OrderDto>>
{
    public async Task<PagedList<OrderDto>> Handle(GetUserOrdersQuery q, CancellationToken ct)
    {
        var userId = currentUser.UserId;
        await accountRepo.ThrowIfDeletedAsync(userId, ct);

        var query = repo.QueryWithIncludes()
            .AsNoTracking()
            .Where(o => o.UserId == userId)
            .ApplyFilters(q)
            .ApplySorting(q.Parameters);

        return await query.ToPagedListAsync<Order, OrderDto>(q.Parameters, mapper, ct);
    }
}