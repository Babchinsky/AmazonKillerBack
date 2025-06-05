using AmazonKiller.Application.Common.Models;

namespace AmazonKiller.Application.Features.Categories.Common;

public interface ICategoriesQuery
{
    public QueryParameters Parameters { get; }
}