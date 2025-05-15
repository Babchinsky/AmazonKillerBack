using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonKiller.Domain.Entities.Orders;

[Table("Addresses")]
public class Address
{
    public Guid Id { get; init; }

    [Required] [StringLength(100)] public string Country { get; init; } = string.Empty;

    [Required] [StringLength(100)] public string City { get; init; } = string.Empty;

    [StringLength(100)] public string? State { get; init; } // Optional: for countries with states/provinces

    [Required] [StringLength(100)] public string Street { get; init; } = string.Empty;

    [Required] [StringLength(20)] public string HouseNumber { get; init; } = string.Empty;

    [StringLength(20)] public string? ApartmentNumber { get; init; }

    [Required] [StringLength(20)] public string PostCode { get; init; } = string.Empty;
}