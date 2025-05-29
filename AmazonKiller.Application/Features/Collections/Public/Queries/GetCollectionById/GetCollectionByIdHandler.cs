using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Interfaces.Repositories.Collections;
using AutoMapper;
using MediatR;

namespace AmazonKiller.Application.Features.Collections.Public.Queries.GetCollectionById;

public class GetCollectionByIdHandler(
    ICollectionRepository repo,
    IMapper mapper
) : IRequestHandler<GetCollectionByIdQuery, CollectionDetailsDto>
{
    public async Task<CollectionDetailsDto> Handle(GetCollectionByIdQuery request, CancellationToken ct)
    {
        var entity = await repo.GetByIdAsync(request.Id, ct)
                     ?? throw new KeyNotFoundException("Collection not found");

        return mapper.Map<CollectionDetailsDto>(entity);
    }
}