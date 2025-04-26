using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Domain.Entities.Orders;

public class OrderItem
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; } // instead of uint

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = null!;

    [Required] public OrderStatus Status { get; set; }

    [Precision(18, 2)] public decimal Price { get; set; }

    [Range(1, int.MaxValue)] public int Quantity { get; set; }

    [Required] public DateTime OrderedAt { get; set; }
}