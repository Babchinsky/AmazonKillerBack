namespace AmazonKiller.Application.DTOs.Collections;

public record CollectionDetailsDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public Guid CategoryId { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public List<CollectionFilterDto> Filters { get; init; } = [];
}