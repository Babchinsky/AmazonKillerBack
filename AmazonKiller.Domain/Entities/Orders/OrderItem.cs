using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Orders;

public class OrderItem
{
    public Guid Id { get; set; }

    [Required] public uint OrderId { get; set; }

    [Required] public OrderStatus Status { get; set; }

    [Range(1, int.MaxValue)] public int Price { get; set; }

    [Range(1, int.MaxValue)] public int Quantity { get; set; }

    [Required] public DateTime OrderedAt { get; set; }
}