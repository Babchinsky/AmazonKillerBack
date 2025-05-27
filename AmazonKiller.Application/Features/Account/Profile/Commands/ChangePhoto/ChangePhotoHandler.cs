using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Account.Profile.Commands.ChangePhoto;

public class ChangePhotoHandler(
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService,
    IFileStorage storage
) : IRequestHandler<ChangePhotoCommand, string>
{
    public async Task<string> Handle(ChangePhotoCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);
        
        var user = await accountRepo.GetCurrentUserAsync(currentUserId, ct)
                   ?? throw new NotFoundException("User not found");

        var oldPhoto = user.ImageUrl;

        // сохраняем новое фото
        await using var stream = cmd.Photo.OpenReadStream();
        var ext = Path.GetExtension(cmd.Photo.FileName);
        var newPath = await storage.SaveAsync(stream, ext, ct);

        // обновляем URL
        typeof(User).GetProperty(nameof(User.ImageUrl))!.SetValue(user, newPath); // обход readonly setter

        await accountRepo.SaveChangesAsync(ct);

        // удаляем старое фото, если было
        if (!string.IsNullOrWhiteSpace(oldPhoto))
            await storage.DeleteAsync(oldPhoto, ct);

        return newPath;
    }
}