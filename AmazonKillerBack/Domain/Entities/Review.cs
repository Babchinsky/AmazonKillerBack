namespace AmazonKillerBack.Domain.Entities;

using System;
using System.ComponentModel.DataAnnotations;

public class Review
{
    public Guid Id { get; set; }
    
    [Required]
    public ReviewContent Content { get; set; } = new ReviewContent();  
    
    public Rating Rating { get; set; }
    
    [Required]
    public Guid ProductId { get; set; }
    
    [Required]
    public Guid UserId { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public int Likes { get; set; }
}