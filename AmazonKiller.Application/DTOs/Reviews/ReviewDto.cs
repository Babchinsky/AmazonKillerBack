namespace AmazonKiller.Application.DTOs.Reviews;

public class ReviewDto
{
    public Guid Id { get; set; }
    public ReviewContentDto Content { get; set; }
    public int Rating { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Likes { get; set; }
}