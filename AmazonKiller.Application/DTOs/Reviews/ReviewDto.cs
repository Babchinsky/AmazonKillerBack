namespace AmazonKiller.Application.DTOs.Reviews;

public class ReviewDto
{
    public Guid Id { get; set; }
    public decimal Rating { get; set; } // от 1 до 5
    public ReviewContentDto Content { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserFullName { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = [];
    public int Likes { get; set; }
}