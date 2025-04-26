using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Shared.Exceptions;

public class NotFoundException(string message)
    : AppException(message, StatusCodes.Status404NotFound);