namespace AmazonKiller.Domain.Entities.Orders;

public enum OrderStatus
{
    Received,
    ReadyForPickup,
    Shipped,
    Cancelled,
    Ordered
}