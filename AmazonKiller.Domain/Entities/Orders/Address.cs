using AmazonKiller.Domain.Entities.Common;

namespace AmazonKiller.Domain.Entities.Orders;

public class Address : BaseEntity
{
    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string? State { get; init; }
    public string Street { get; init; } = string.Empty;
    public string HouseNumber { get; init; } = string.Empty;
    public string? ApartmentNumber { get; init; }
    public string PostCode { get; init; } = string.Empty;
}