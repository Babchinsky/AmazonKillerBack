using System.ComponentModel.DataAnnotations;

namespace AmazonKillerBack.Domain.Entities;

public class Address
{
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; }

    [Required]
    [StringLength(100)]
    public string City { get; set; }

    [Required]
    [StringLength(100)]
    public string Street { get; set; }

    [Required]
    [StringLength(20)]
    public string HouseNumber { get; set; }

    [StringLength(20)]
    public string? ApartmentNumber { get; set; }

    [Required]
    [StringLength(20)]
    public string PostCode { get; set; }
}