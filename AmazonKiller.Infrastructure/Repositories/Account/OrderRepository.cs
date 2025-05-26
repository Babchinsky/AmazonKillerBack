using AmazonKiller.Application.DTOs.Account.Orders;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class OrderRepository(AmazonDbContext db, IMapper mapper) : IOrderRepository
{
    private IQueryable<Order> QueryOrderWithAllIncludes()
    {
        return db.Orders
            .Include(o => o.Info)
            .ThenInclude(i => i.Delivery)
            .ThenInclude(d => d.Address)
            .Include(o => o.Info)
            .ThenInclude(i => i.Payment)
            .Include(o => o.User)
            .Include(o => o.Items)
            .ThenInclude(i => i.Product);
    }

    public async Task<List<OrderDto>> GetUserOrdersAsync(Guid userId, CancellationToken ct)
    {
        var orders = await db.Orders
            .Include(o => o.Info)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.Info.OrderedAt)
            .ToListAsync(ct);

        return mapper.Map<List<OrderDto>>(orders);
    }

    public IQueryable<Order> QueryWithIncludes()
    {
        return db.Orders
            .Include(o => o.Info)
            .Include(o => o.User);
    }

    public async Task<OrderDetailsDto> GetOrderDetailsAsync(Guid userId, Guid orderId, CancellationToken ct)
    {
        var order = await QueryOrderWithAllIncludes()
            .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId, ct);

        if (order is null)
            throw new NotFoundException("Order not found");

        var items = mapper.Map<List<OrderItemDto>>(order.Items);

        var d = order.Info.Delivery;

        return new OrderDetailsDto
        {
            Id = order.Id,
            Price = order.TotalPrice,
            Status = order.Status.ToString(),
            OrderedAt = order.Info.OrderedAt,
            Address =
                $"{d.Address.Country}, {d.Address.State}, {d.Address.City}, {d.Address.Street}, {d.Address.HouseNumber}",
            Recipient = $"{d.FirstName} {d.LastName}",
            PaymentType = order.Info.Payment.PaymentType.ToString(),
            Items = items
        };
    }

    public async Task<Guid> CreateOrderAsync(Order order, CancellationToken ct)
    {
        db.Orders.Add(order);
        await db.SaveChangesAsync(ct);
        return order.Id;
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus newStatus, CancellationToken ct)
    {
        var order = await db.Orders.FirstOrDefaultAsync(o => o.Id == orderId, ct)
                    ?? throw new NotFoundException("Order not found");

        order.Status = newStatus;
        await db.SaveChangesAsync(ct);
    }
}