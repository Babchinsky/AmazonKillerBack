namespace AmazonKiller.Application.Common.Models;

public class QueryParameters
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SortBy { get; set; }
    public string SortOrder { get; set; } = "asc"; // asc or desc
}