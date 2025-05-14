namespace AmazonKiller.Application.Interfaces.Services;

public interface ICurrentRequestContext
{
    string IpAddress { get; }
    string UserAgent { get; }
}