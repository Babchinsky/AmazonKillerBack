using System.Linq.Expressions;
using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Domain.Entities.Users;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetAllUsers;

public static class UserQueryExtensions
{
    public static IQueryable<User> ApplyUserFilters(this IQueryable<User> query, GetAllUsersQuery request)
    {
        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(u =>
                u.FirstName.Contains(request.Search) ||
                u.LastName.Contains(request.Search) ||
                u.Email.Contains(request.Search));

        if (!string.IsNullOrWhiteSpace(request.Role) &&
            Enum.TryParse<Role>(request.Role, true, out var role))
            query = query.Where(u => u.Role == role);

        if (!string.IsNullOrWhiteSpace(request.Status) &&
            Enum.TryParse<UserStatus>(request.Status, true, out var status))
            query = query.Where(u => u.Status == status);

        return query;
    }

    public static IQueryable<User> ApplyUserSorting(this IQueryable<User> query, QueryParameters parameters)
    {
        var sortMap = new Dictionary<string, Expression<Func<User, object>>>
        {
            ["firstname"] = u => u.FirstName,
            ["lastname"] = u => u.LastName,
            ["email"] = u => u.Email,
            ["role"] = u => u.Role,
            ["status"] = u => u.Status,
            ["createdat"] = u => u.CreatedAt
        };

        return query.ApplySorting(parameters, sortMap);
    }
}