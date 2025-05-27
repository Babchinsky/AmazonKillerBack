using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangePhoto;

public class ChangePhotoCommand : IRequest<string>
{
    public IFormFile Photo { get; init; } = null!;
}