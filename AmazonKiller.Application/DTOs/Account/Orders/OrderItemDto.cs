namespace AmazonKiller.Application.DTOs.Account.Orders;

public record OrderItemDto(
    Guid Id,
    string Name,
    string ImageUrl,
    int Quantity,
    decimal Price
);