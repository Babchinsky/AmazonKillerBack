namespace AmazonKiller.Application.DTOs.Collections;

public record CollectionCardDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? ImageUrl { get; init; }
}