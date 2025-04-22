using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Application.DTOs.Account;

public record UpdateProfilePhotoDto(IFormFile Photo);