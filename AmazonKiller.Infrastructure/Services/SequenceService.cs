using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Common;
using AmazonKiller.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Infrastructure.Services;

public class SequenceService(AmazonDbContext db) : ISequenceService
{
    public async Task<int> GetNextAsync(string name, CancellationToken ct = default)
    {
        var entity = await db.Sequences.FirstOrDefaultAsync(s => s.Name == name, ct);

        if (entity is null)
        {
            entity = new Sequence { Name = name, LastValue = 1 };
            db.Sequences.Add(entity);
        }
        else
        {
            entity.LastValue++;
        }

        await db.SaveChangesAsync(ct);
        return entity.LastValue;
    }
}