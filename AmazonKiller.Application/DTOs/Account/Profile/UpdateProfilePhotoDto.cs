using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.DTOs.Account.Profile;

public record UpdateProfilePhotoDto(IFormFile Photo);