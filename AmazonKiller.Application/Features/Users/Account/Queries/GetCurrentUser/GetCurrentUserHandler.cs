using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Account.Queries.GetCurrentUser;

public class GetCurrentUserHandler(
    ICurrentUserService currentUser,
    IAccountRepository accountRepo,
    IMapper mapper
) : IRequestHandler<GetCurrentUserQuery, UserInfoDto>
{
    public async Task<UserInfoDto> Handle(GetCurrentUserQuery _, CancellationToken ct)
    {
        var currentUserId = currentUser.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var user = await accountRepo.GetUserByIdAsync(currentUserId, ct);
        if (user is null) throw new UnauthorizedAccessException("User not found");

        return mapper.Map<UserInfoDto>(user);
    }
}