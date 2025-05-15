using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using AmazonKiller.Domain.Entities.Products;

namespace AmazonKiller.Domain.Entities.Sales;

public class Sale
{
    public Guid Id { get; init; }

    public Guid? ProductId { get; init; }
    public Product? Product { get; init; }

    public Guid? CategoryId { get; init; }

    [Precision(18, 2)] public decimal OldPrice { get; init; }

    [Precision(18, 2)] public decimal NewPrice { get; init; }

    public int DiscountPercent => OldPrice == 0 ? 0 : (int)Math.Round((OldPrice - NewPrice) / OldPrice * 100);

    [Required] public DateTime StartDate { get; init; }

    [Required] public DateTime EndDate { get; init; }

    public bool IsValidDateRange => EndDate >= StartDate;
}