namespace AmazonKiller.Application.Interfaces.Services;

public interface IPropertyKeyUpdater
{
    /// <summary>
    /// Обновляет PropertyKeys категории:
    /// - добавляет новые ключи, если они появились,
    /// - удаляет старые, если они больше не используются ни в одном товаре этой категории.
    /// </summary>
    Task UpdateCategoryPropertyKeysAsync(
        Guid categoryId,
        IEnumerable<string> usedKeysNow,
        CancellationToken ct);
}