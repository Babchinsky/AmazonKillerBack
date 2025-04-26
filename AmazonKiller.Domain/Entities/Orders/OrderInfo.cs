namespace AmazonKiller.Domain.Entities.Orders;

public class OrderInfo
{
    public Guid Id { get; set; }

    public DeliveryInfo Delivery { get; set; } = new();
    public PaymentInfo Payment { get; set; } = new();

    public DateTime OrderedAt { get; set; }
}