using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Common.Models;
using AmazonKiller.Application.DTOs.Admin.Users;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersHandler(IAdminUserRepository repo, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, PagedList<UserAdminDto>>
{
    public async Task<PagedList<UserAdminDto>> Handle(GetAllUsersQuery request, CancellationToken ct)
    {
        var query = repo.Queryable().AsNoTracking()
            .ApplyUserFilters(request)
            .ApplyUserSorting(request.Parameters);

        return await query.ToPagedListAsync<User, UserAdminDto>(request.Parameters, mapper, ct);
    }
}