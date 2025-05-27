using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Common;

public class Sequence
{
    [Key] public string Name { get; init; } = string.Empty;

    public int LastValue { get; set; }
}