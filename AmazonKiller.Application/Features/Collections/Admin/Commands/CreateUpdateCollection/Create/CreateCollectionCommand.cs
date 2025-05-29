using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Create;

public record CreateCollectionCommand : UpsertCollectionModel,
    IRequest<CollectionDetailsDto>;