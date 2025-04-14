using AmazonKillerBack.Domain.Entities.Users;

namespace AmazonKillerBack.Domain.Entities.Orders;

public class AddInfo
{
    public Guid Id { get; set; }
    
    public string FullName { get; set; } = string.Empty;

    public Address Address { get; set; } = new();

    public PaymentType PaymentType { get; set; }

    public DateTime OrderedAt { get; set; }
}