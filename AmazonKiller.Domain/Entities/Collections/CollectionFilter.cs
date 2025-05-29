namespace AmazonKiller.Domain.Entities.Collections;

public class CollectionFilter
{
    public Guid CollectionId { get; init; }
    public Collection Collection { get; init; } = null!;

    public string Key { get; init; } = null!;
    public string Value { get; init; } = null!;
}