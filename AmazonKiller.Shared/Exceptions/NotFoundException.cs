using Microsoft.AspNetCore.Http;

namespace AmazonKiller.Shared.Exceptions;

public class NotFoundException : AppException
{
    public Guid RequestId { get; }

    // Конструктор, который принимает сообщение и Id
    public NotFoundException(string message, Guid requestId)
        : base(message, StatusCodes.Status404NotFound)
    {
        RequestId = requestId;
    }

    // Конструктор, который только принимает сообщение
    public NotFoundException(string message)
        : base(message, StatusCodes.Status404NotFound)
    {
    }
}