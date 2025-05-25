namespace AmazonKiller.Application.DTOs.Reviews;

public class ReviewDto
{
    public Guid Id { get; set; }
    public decimal Rating { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserFullName { get; set; } = string.Empty;
    public string UserImageUrl { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public List<string> ImageUrls { get; set; } = [];
    public List<string> Tags { get; set; } = [];
    public int Likes { get; set; }
    public string RowVersion { get; init; } = string.Empty;
}