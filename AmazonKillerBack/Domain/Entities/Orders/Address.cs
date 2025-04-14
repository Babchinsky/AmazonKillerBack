using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Domain.Entities.Orders;

public class Address
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Street { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string HouseNumber { get; set; } = string.Empty;

    [StringLength(20)]
    public string? ApartmentNumber { get; set; }

    [Required]
    [StringLength(20)]
    public string PostCode { get; set; } = string.Empty;
}
