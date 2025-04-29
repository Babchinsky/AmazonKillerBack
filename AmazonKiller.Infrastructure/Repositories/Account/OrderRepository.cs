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
    private async Task RecalculateOrderTotalPriceAsync(Guid orderId, CancellationToken ct)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId, ct);

        if (order == null)
            return;

        order.TotalPrice = order.Items.Sum(i => i.Price * i.Quantity);
        await db.SaveChangesAsync(ct);
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

    public async Task<OrderDetailsDto> GetOrderDetailsAsync(Guid userId, Guid orderId, CancellationToken ct)
    {
        var order = await db.Orders
            .Include(o => o.Info)
            .ThenInclude(i => i.Delivery)
            .ThenInclude(deliveryInfo => deliveryInfo.Address)
            .Include(o => o.Info)
            .ThenInclude(i => i.Payment)
            .Include(o => o.User)
            .Include(o => o.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId, ct);

        if (order is null)
            throw new NotFoundException("Order not found");

        var items = order.Items.Select(i => new OrderItemDto(
            i.Id,
            i.Product.Name,
            i.Product.ProductPics.FirstOrDefault() ?? "",
            i.Quantity,
            i.Price)).ToList();

        var d = order.Info.Delivery;

        return new OrderDetailsDto(
            order.Id,
            order.TotalPrice,
            order.Status.ToString(),
            order.Info.OrderedAt,
            $"{d.Address.Country}, {d.Address.State}, {d.Address.City}, {d.Address.Street}, {d.Address.HouseNumber}",
            $"{order.User.FirstName} {order.User.LastName}",
            order.Info.Payment.PaymentType.ToString(),
            items
        );
    }

    public async Task<Guid> CreateOrderAsync(Order order, CancellationToken ct)
    {
        db.Orders.Add(order);
        await db.SaveChangesAsync(ct);
        return order.Id;
    }

    public async Task AddProductToOrderAsync(Guid orderId, Guid productId, int quantity, CancellationToken ct)
    {
        var order = await db.Orders
                        .Include(o => o.Items)
                        .FirstOrDefaultAsync(o => o.Id == orderId, ct)
                    ?? throw new NotFoundException("Order not found");

        var product = await db.Products
                          .AsNoTracking()
                          .FirstOrDefaultAsync(p => p.Id == productId, ct)
                      ?? throw new NotFoundException("Product not found");

        var item = order.Items.FirstOrDefault(i => i.ProductId == productId);

        if (item != null)
            item.Quantity += quantity;
        else
            order.Items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = productId,
                Price = product.Price,
                Quantity = quantity,
                Status = OrderStatus.Ordered,
                OrderedAt = DateTime.UtcNow
            });

        await db.SaveChangesAsync(ct);
        await RecalculateOrderTotalPriceAsync(orderId, ct);
    }

    public async Task RemoveProductFromOrderAsync(Guid orderId, Guid orderItemId, CancellationToken ct)
    {
        var order = await db.Orders
                        .Include(o => o.Items)
                        .FirstOrDefaultAsync(o => o.Id == orderId, ct)
                    ?? throw new NotFoundException("Order not found");

        var item = order.Items.FirstOrDefault(i => i.Id == orderItemId)
                   ?? throw new NotFoundException("Order item not found");

        order.Items.Remove(item);

        if (!order.Items.Any()) db.Orders.Remove(order); // Если удалили последний товар — удаляем весь заказ

        await db.SaveChangesAsync(ct);

        if (db.Orders.Any(o => o.Id == orderId)) // Если заказ остался — пересчитываем сумму
            await RecalculateOrderTotalPriceAsync(orderId, ct);
    }
}