namespace AmazonKiller.Application.DTOs.Account.Orders;

public record OrderDetailsDto(
    Guid Id,
    long OrderNumber,
    decimal Price,
    string Status,
    DateTime OrderedAt,
    string Address,
    string Recipient,
    string PaymentType,
    List<OrderItemDto> Items
);