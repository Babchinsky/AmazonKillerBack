using System.ComponentModel.DataAnnotations;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Users;

public class CartList
{
    public Guid Id { get; init; }

    [Required] public Guid UserId { get; init; }

    [Required] public Guid ProductId { get; init; }
    public Product Product { get; init; } = null!;

    [Range(1, int.MaxValue)] public int Quantity { get; set; }

    [Range(0.01, double.MaxValue)] public decimal Price { get; init; } // за 1 единицу на момент добавления

    public DateTime AddedAt { get; init; }
}