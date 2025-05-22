namespace AmazonKiller.Application.DTOs.Account.Wishlist;

public class ProductInWishlistDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = "";
    public string ImageUrl { get; init; } = "";
    public decimal Price { get; init; }
    public decimal? OldPrice { get; init; }
    public decimal Rating { get; init; }
    public int ReviewsCount { get; init; }
    public DateTime AddedAt { get; init; }
}