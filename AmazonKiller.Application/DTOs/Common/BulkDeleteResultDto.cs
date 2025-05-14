namespace AmazonKiller.Application.DTOs.Common;

public class BulkDeleteResultDto
{
    public int DeletedCount { get; set; }
    public List<Guid> NotFoundIds { get; set; } = [];
}