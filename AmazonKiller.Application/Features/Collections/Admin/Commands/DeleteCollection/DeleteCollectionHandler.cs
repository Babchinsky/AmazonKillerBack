using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AmazonKiller.Application.Interfaces.Services;
using AmazonKiller.Shared.Exceptions;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.DeleteCollection;

public class DeleteCollectionHandler(
    ICollectionRepository repo,
    IFileStorage fileStorage
) : IRequestHandler<DeleteCollectionCommand>
{
    public async Task Handle(DeleteCollectionCommand request, CancellationToken ct)
    {
        var entity = await repo.GetByIdAsync(request.Id, ct)
                     ?? throw new NotFoundException("Collection not found");

        await repo.DeleteAsync(entity, ct);
    }
}