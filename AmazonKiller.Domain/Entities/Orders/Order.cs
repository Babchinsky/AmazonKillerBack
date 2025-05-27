using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Domain.Entities.Orders;

public class Order : VersionedEntity
{
    public string OrderNumber { get; init; } = string.Empty;
    public OrderInfo Info { get; init; } = new();
    public ICollection<OrderItem> Items { get; init; } = new List<OrderItem>();
    public OrderStatus Status { get; set; } = OrderStatus.Ordered;
    [Precision(18, 2)] public decimal TotalPrice { get; set; }
    public Guid UserId { get; init; }
    public User User { get; init; } = null!;
}