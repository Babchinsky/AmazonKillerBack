namespace AmazonKiller.Infrastructure.Data.Helpers;

public static class SeedPasswordHelper
{
    private const string FixedSalt = "$2a$11$0123456789ABCDEFFEDCBA";

    /// <summary>
    /// Генерация детерминированного хэша пароля для сидинга (на основе фиксированной соли).
    /// </summary>
    public static string Hash(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, FixedSalt);
    }
}