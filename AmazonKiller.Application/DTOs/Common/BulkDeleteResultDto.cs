namespace AmazonKiller.Application.DTOs.Common;

public record BulkDeleteResultDto
{
    public int DeletedCount { get; init; }
    public List<Guid> NotFoundIds { get; init; } = [];
}