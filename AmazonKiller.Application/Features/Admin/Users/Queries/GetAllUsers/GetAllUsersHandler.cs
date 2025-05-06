using AmazonKiller.Application.DTOs.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Admin.Users.Queries.GetAllUsers;

public class GetAllUsersHandler(IAdminUserRepository repo, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, List<UserAdminDto>>
{
    public async Task<List<UserAdminDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
    {
        var query = repo.Queryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(u =>
                u.FirstName.Contains(request.Search) ||
                u.LastName.Contains(request.Search) ||
                u.Email.Contains(request.Search));

        if (!string.IsNullOrWhiteSpace(request.Role) && Enum.TryParse<Role>(request.Role, true, out var role))
            query = query.Where(u => u.Role == role);

        return await query
            .OrderBy(u => u.FirstName)
            .ProjectTo<UserAdminDto>(mapper.ConfigurationProvider)
            .ToListAsync(ct);
    }
}