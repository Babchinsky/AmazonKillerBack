using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class CartList
{
    public Guid Id { get; set; }

    [Required] public Guid UserId { get; set; }

    [Required] public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    [Range(1, int.MaxValue)] public int Quantity { get; set; }

    [Range(0.01, double.MaxValue)] public decimal Price { get; set; } // за 1 единицу на момент добавления

    public DateTime AddedAt { get; set; }
}