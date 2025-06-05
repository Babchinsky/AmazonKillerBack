namespace AmazonKiller.Infrastructure.Data.Helpers;

public static class SeedHelper
{
    private const string FixedSalt = "$2a$11$0123456789ABCDEFFEDCBA";

    /// <summary>
    /// Генерация детерминированного хэша пароля для сидинга (на основе фиксированной соли).
    /// </summary>
    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, FixedSalt);
    }

    public static List<string>? KeysOrNull(Guid categoryId, Dictionary<Guid, List<string>> map)
    {
        return map.TryGetValue(categoryId, out var keys) && keys.Count != 0 ? keys : null;
    }
}