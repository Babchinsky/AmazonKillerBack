namespace AmazonKiller.Domain.Entities.Orders;

public class DeliveryInfo
{
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
    public string Email { get; init; } = "";
    public Address Address { get; init; } = new();
}