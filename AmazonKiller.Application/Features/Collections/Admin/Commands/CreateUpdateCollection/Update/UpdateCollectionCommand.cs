using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Update;

public record UpdateCollectionCommand : UpsertCollectionModel,
    IRequest<CollectionDetailsDto>
{
    public Guid Id { get; init; }
}