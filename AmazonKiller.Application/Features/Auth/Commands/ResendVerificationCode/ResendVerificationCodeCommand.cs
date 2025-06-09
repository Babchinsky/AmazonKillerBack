using AmazonKiller.Domain.Entities.Users;
using MediatR;

namespace AmazonKiller.Application.Features.Auth.Commands.ResendVerificationCode;

public record ResendVerificationCodeCommand(
    string Email,
    VerificationType Type
) : IRequest;