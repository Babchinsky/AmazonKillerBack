using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Domain.Entities.Orders;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; init; } // instead of uint

    public Guid ProductId { get; init; }

    public Product Product { get; init; } = null!;

    [Precision(18, 2)] public decimal Price { get; init; }

    [Range(1, int.MaxValue)] public int Quantity { get; set; }

    [Required] public DateTime OrderedAt { get; init; }
}