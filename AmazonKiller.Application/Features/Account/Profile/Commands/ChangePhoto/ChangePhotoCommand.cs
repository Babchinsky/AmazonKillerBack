using MediatR;
using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangePhoto;

public class ChangePhotoCommand : IRequest<string> // возвращаем URL новой фотографии
{
    public IFormFile Photo { get; init; } = null!;
}