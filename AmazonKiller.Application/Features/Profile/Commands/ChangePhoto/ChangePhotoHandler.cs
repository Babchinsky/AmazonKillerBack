﻿using AmazonKiller.Application.Common.Helpers;
using AmazonKiller.Application.Interfaces.Repositories.Account;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Domain.Entities.Users;
using AmazonKiller.Shared.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace AmazonKiller.Application.Features.Profile.Commands.ChangePhoto;

public class ChangePhotoHandler(
    IAccountRepository accountRepo,
    ICurrentUserService currentUserService,
    IFileStorage storage,
    IHttpContextAccessor httpContextAccessor,
    IHostEnvironment env
) : IRequestHandler<ChangePhotoCommand, string>
{
    public async Task<string> Handle(ChangePhotoCommand cmd, CancellationToken ct)
    {
        var currentUserId = currentUserService.UserId;
        await accountRepo.ThrowIfDeletedAsync(currentUserId, ct);

        var user = await accountRepo.GetUserByIdAsync(currentUserId, ct)
                   ?? throw new NotFoundException("User not found");

        var oldPhoto = user.ImageUrl;

        // сохраняем новое фото
        await using var stream = cmd.Photo.OpenReadStream();
        var ext = Path.GetExtension(cmd.Photo.FileName);
        var newPath = await storage.SaveAsync(stream, ext, ct);

        // обновляем URL
        typeof(User).GetProperty(nameof(User.ImageUrl))!.SetValue(user, newPath);

        await accountRepo.SaveChangesAsync(ct);

        // удаляем старое фото, если было
        if (!string.IsNullOrWhiteSpace(oldPhoto))
            await storage.DeleteAsync(oldPhoto, ct);

        // ✅ Возвращаем абсолютный URL
        var absoluteUrl = ImageUrlHelper.ToAbsoluteUrl(newPath, httpContextAccessor.HttpContext?.Request, env);
        return absoluteUrl;
    }
}