namespace AmazonKiller.Domain.Entities.Common;

public abstract class VersionedEntity : BaseEntity
{
    public byte[] RowVersion { get; set; } = [];
}