using AmazonKiller.Application.DTOs.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Account.Queries.GetCurrentUser;

public record GetCurrentUserQuery : IRequest<UserInfoDto>;