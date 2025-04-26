using AmazonKiller.Application.DTOs.Account;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Domain.Entities.Orders;
using AmazonKiller.Infrastructure.Data;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Repositories.Account;

public class OrderRepository(AmazonDbContext db, IMapper mapper) : IOrderRepository
{
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
            0, // Removed old OrderId
            order.TotalPrice,
            order.Status.ToString(),
            order.Info.OrderedAt,
            $"{d.Address.Country}, {d.Address.State}, {d.Address.City}, {d.Address.Street}, {d.Address.HouseNumber}",
            $"{order.User.FirstName} {order.User?.LastName}",
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
            .FirstOrDefaultAsync(o => o.Id == orderId, ct);

        if (order == null)
            throw new NotFoundException("Order not found");

        var product = await db.Products
            .FirstOrDefaultAsync(p => p.Id == productId, ct);

        if (product == null)
            throw new NotFoundException("Product not found");

        var existingItem = order.Items.FirstOrDefault(i => i.ProductId == product.Id);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = product.Id,
                Status = OrderStatus.Ordered,
                Price = product.Price, // цена за единицу товара
                Quantity = quantity,
                OrderedAt = DateTime.UtcNow
            };

            db.OrderItems.Add(orderItem);
            order.Items.Add(orderItem);
        }

        order.TotalPrice = order.Items.Sum(i => i.Price * i.Quantity);

        await db.SaveChangesAsync(ct);
    }

    public async Task RemoveProductFromOrderAsync(Guid orderId, Guid orderItemId, CancellationToken ct)
    {
        var order = await db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId, ct);

        if (order == null)
            throw new NotFoundException("Order not found");

        var item = order.Items.FirstOrDefault(i => i.Id == orderItemId);
        if (item == null)
            throw new NotFoundException("Order item not found");

        order.TotalPrice -= item.Price;
        order.Items.Remove(item);
        await db.SaveChangesAsync(ct);
    }
}