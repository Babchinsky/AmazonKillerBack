namespace AmazonKiller.Application.DTOs.Reviews;

public class ReviewDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; } // от 1 до 5
    public string Message { get; set; } = string.Empty;
    public string Article { get; set; } = string.Empty;
    public List<string> FilePaths { get; set; } = new();
    public ReviewContentDto Content { get; set; }
    public int Rating { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserFullName { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
    public int Likes { get; set; }
}