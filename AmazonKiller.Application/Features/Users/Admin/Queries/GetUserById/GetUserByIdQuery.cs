using AmazonKiller.Application.DTOs.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Users.Admin.Queries.GetUserById;

public record GetUserByIdQuery(Guid Id) : IRequest<UserAdminDto>;