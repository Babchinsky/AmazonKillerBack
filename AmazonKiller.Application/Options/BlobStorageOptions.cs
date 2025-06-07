namespace AmazonKiller.Application.Options;

public class BlobStorageOptions
{
    public string ConnectionString { get; init; } = string.Empty;
    public string ContainerName { get; init; } = "uploads";
}