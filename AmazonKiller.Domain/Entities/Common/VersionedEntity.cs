using System.ComponentModel.DataAnnotations;

namespace AmazonKiller.Domain.Entities.Common;

public abstract class VersionedEntity : BaseEntity
{
    [Timestamp] // важна аннотация
    public byte[] RowVersion { get; set; } = [];
}