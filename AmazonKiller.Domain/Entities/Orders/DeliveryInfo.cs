namespace AmazonKiller.Domain.Entities.Orders;

public class DeliveryInfo
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public Address Address { get; set; } = new();
}