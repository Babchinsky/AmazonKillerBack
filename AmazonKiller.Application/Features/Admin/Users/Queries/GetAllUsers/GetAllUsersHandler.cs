using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.DTOs.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetAllUsers;

public class GetAllUsersHandler(IAdminUserRepository repo, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, List<UserAdminDto>>
{
    public async Task<List<UserAdminDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking();

        // Поиск по имени, фамилии, email
        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(u =>
                u.FirstName.Contains(request.Search) ||
                u.LastName.Contains(request.Search) ||
                u.Email.Contains(request.Search));

        // Фильтр по роли
        if (!string.IsNullOrWhiteSpace(request.Role) && Enum.TryParse<Role>(request.Role, true, out var role))
            query = query.Where(u => u.Role == role);

        // Фильтр по статусу
        if (!string.IsNullOrWhiteSpace(request.Status) &&
            Enum.TryParse<UserStatus>(request.Status, true, out var status))
            query = query.Where(u => u.Status == status);

        // Словарь для сортировки
        var sortMap = new Dictionary<string, Expression<Func<User, object>>>
        {
            ["firstname"] = u => u.FirstName,
            ["lastname"] = u => u.LastName,
            ["email"] = u => u.Email,
            ["role"] = u => u.Role,
            ["status"] = u => u.Status,
            ["createdat"] = u => u.CreatedAt
        };

        query = query
            .ApplySorting(request.Parameters, sortMap)
            .ApplyPagination(request.Parameters);

        return await query
            .ProjectTo<UserAdminDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }
}