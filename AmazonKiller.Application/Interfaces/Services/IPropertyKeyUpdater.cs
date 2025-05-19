namespace AmazonKiller.Application.Interfaces.Services
{
    public interface IPropertyKeyUpdater
    {
        Task UpdateCategoryPropertyKeysAsync(
            Guid categoryId,
            IEnumerable<string> usedKeys,
            CancellationToken ct);
    }
}