namespace AmazonKiller.Domain.Entities.Orders;

public class OrderInfo
{
    public Guid Id { get; set; }

    public DeliveryInfo Delivery { get; init; } = new();
    public PaymentInfo Payment { get; init; } = new();

    public DateTime OrderedAt { get; init; }
}