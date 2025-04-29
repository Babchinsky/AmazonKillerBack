namespace AmazonKiller.Application.DTOs.Account.Orders;

public record OrderDetailsDto(
    Guid Id,
    decimal Price,
    string Status,
    DateTime OrderedAt,
    string Address,
    string Recipient,
    string PaymentType,
    List<OrderItemDto> Items
);