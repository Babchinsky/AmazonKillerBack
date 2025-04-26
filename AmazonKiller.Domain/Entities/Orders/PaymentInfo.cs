namespace AmazonKiller.Domain.Entities.Orders;

public class PaymentInfo
{
    public PaymentType PaymentType { get; set; }

    public string? CardNumber { get; set; } // Nullable
    public string? ExpirationDate { get; set; }
    public string? Cvv { get; set; }
}