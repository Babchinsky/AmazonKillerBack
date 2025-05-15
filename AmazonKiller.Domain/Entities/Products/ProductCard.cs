using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Domain.Entities.Products;

public class ProductCard
{
    public int Id { get; init; }

    [Required] public string ImageUrl { get; init; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Name { get; init; }

    [Precision(18, 2)] public decimal Price { get; init; }

    public Rating Rating { get; init; }

    public bool Sale { get; init; }

    [Required] public Guid ProductId { get; init; }

    [Range(0, int.MaxValue)] public int ReviewsCount { get; init; }
}