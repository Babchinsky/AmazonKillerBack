using AmazonKiller.Application.DTOs.Collections;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Public.Queries.GetCollectionById;

public record GetCollectionByIdQuery(Guid Id) : IRequest<CollectionDetailsDto>;