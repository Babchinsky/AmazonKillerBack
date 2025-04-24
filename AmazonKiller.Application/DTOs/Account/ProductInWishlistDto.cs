namespace AmazonKiller.Application.DTOs.Account;

public class ProductInWishlistDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string ImageUrl { get; set; } = "";
    public decimal Price { get; set; }
    public decimal? OldPrice { get; set; }
    public double Rating { get; set; }
    public int ReviewsCount { get; set; }
    public DateTime AddedAt { get; set; }
}
