namespace AmazonKiller.Domain.Entities.Orders;

public class PaymentInfo
{
    public PaymentType PaymentType { get; init; }

    public string? CardNumber { get; set; } // Nullable
    public string? ExpirationDate { get; set; }
    public string? Cvv { get; set; }
}