using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Sales;

public class Sale
{
    public Guid Id { get; set; }
    
    public Guid? ProductId { get; set; }  

    public Guid? CategoryId { get; set; } 

    [Range(0.01, double.MaxValue)]
    public decimal OldPrice { get; set; }

    [Range(0.01, double.MaxValue)]
    public decimal NewPrice { get; set; }

    public int DiscountPercent => OldPrice == 0 ? 0 : (int)Math.Round((OldPrice - NewPrice) / OldPrice * 100);

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
    
    public bool IsValidDateRange => EndDate >= StartDate;
}