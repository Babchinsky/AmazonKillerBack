using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Dac;

namespace AmazonKiller.Infrastructure.Data;

public static class BacpacImporter
{
    public static void ReplaceDatabaseFromBacpac(string server, string user, string password, string bacpacPath,
        string databaseName)
    {
        var masterConn =
            $"Server={server};Database=master;User ID={user};Password={password};TrustServerCertificate=True;";
        var dbConn = $"Server={server};User ID={user};Password={password};TrustServerCertificate=True;";

        using var conn = new SqlConnection(masterConn);
        conn.Open();
        using var cmd = conn.CreateCommand();

        // Удаление базы, если она существует
        cmd.CommandText = $"""

                                       IF EXISTS (SELECT name FROM sys.databases WHERE name = '{databaseName}')
                                       BEGIN
                                           ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                           DROP DATABASE [{databaseName}];
                                       END
                           """;
        cmd.ExecuteNonQuery();

        // Импорт
        var svc = new DacServices(dbConn);
        var bacpac = BacPackage.Load(bacpacPath);
        svc.ImportBacpac(bacpac, databaseName);
    }
}