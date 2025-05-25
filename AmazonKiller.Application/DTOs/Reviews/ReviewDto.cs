namespace AmazonKiller.Application.DTOs.Reviews;

public record ReviewDto
{
    public Guid Id { get; init; }
    public decimal Rating { get; init; }
    public Guid ProductId { get; init; }
    public Guid UserId { get; init; }
    public DateTime CreatedAt { get; init; }
    public string UserFullName { get; init; } = string.Empty;
    public string UserImageUrl { get; init; } = string.Empty;
    public string Article { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public List<string> ImageUrls { get; init; } = [];
    public List<string> Tags { get; init; } = [];
    public int Likes { get; init; }
    public string RowVersion { get; init; } = string.Empty;
}