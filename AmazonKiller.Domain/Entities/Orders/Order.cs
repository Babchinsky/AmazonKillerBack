using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Orders;

public class Order
{
    public Guid Id { get; set; }

    [Required]
    public uint OrderId { get; set; }

    [Required]
    public OrderStatus Status { get; set; }

    [Range(1, int.MaxValue)]
    public int Price { get; set; }

    [Required]
    public ICollection<Product> Products { get; set; } = new List<Product>();

    [Required]
    public Address Address { get; set; }

    public static Order FromOrderItem(OrderItem item)
    {
        return new Order
        {
            OrderId = item.OrderId,
            Status = item.Status,
            Price = item.Price
        };
    }
}

