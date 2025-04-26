namespace AmazonKiller.Application.DTOs.Account.Orders;

public class OrderDto
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime OrderedAt { get; set; }
}