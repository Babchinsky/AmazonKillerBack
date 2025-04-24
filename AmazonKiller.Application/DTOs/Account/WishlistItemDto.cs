namespace AmazonKiller.Application.DTOs.Account;

public record WishlistItemDto(
    Guid Id,
    string Name,
    string ImageUrl,
    decimal Price,
    decimal? OldPrice,
    double Rating
);