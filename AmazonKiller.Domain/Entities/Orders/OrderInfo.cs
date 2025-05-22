using AmazonKiller.Domain.Entities.Common;

namespace AmazonKiller.Domain.Entities.Orders;

public class OrderInfo : BaseEntity
{
    public DeliveryInfo Delivery { get; init; } = new();
    public PaymentInfo Payment { get; init; } = new();

    public DateTime OrderedAt { get; init; }
}