namespace AmazonKiller.Application.DTOs.Account.Wishlist;

public record WishlistItemDto(
    Guid Id,
    string Name,
    string ImageUrl,
    decimal Price,
    decimal? OldPrice,
    decimal Rating
);