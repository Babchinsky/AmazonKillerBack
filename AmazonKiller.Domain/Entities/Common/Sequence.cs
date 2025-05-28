namespace AmazonKiller.Domain.Entities.Common;

public class Sequence
{
    public string Name { get; init; } = string.Empty;
    public int LastValue { get; set; }
}