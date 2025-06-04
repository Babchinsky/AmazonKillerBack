using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Application.Interfaces.Repositories.Admin.Users;
using AmazonKiller.Shared.Exceptions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserById;

public class GetUserByIdHandler(
    IAdminUserRepository repo,
    IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, UserAdminDto>
{
    public async Task<UserAdminDto> Handle(GetUserByIdQuery request, CancellationToken ct)
    {
        var user = await repo.Queryable()
            .FirstOrDefaultAsync(u => u.Id == request.Id, ct);

        return mapper.Map<UserAdminDto>(user)
               ?? throw new NotFoundException("User not found");
    }
}