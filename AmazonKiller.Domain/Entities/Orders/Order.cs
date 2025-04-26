using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Domain.Entities.Orders;

public class Order
{
    public Guid Id { get; set; }

    public OrderInfo Info { get; set; } = new();
    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    public OrderStatus Status { get; set; } = OrderStatus.Received;

    [Precision(18, 2)] public decimal TotalPrice { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}