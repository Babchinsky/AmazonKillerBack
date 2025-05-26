namespace AmazonKiller.Application.DTOs.Common;

public record BulkRestoreResultDto
{
    public int RestoredCount { get; init; }
    public List<Guid> NotFoundIds { get; init; } = [];
}