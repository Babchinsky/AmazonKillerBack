using AmazonKiller.Application.DTOs.Collections;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Create;
using AmazonKiller.Application.Features.Collections.Admin.Commands.CreateUpdateCollection.Update;
using AmazonKiller.Application.Mappings.ImageUrlResolvers;
using AmazonKiller.Domain.Entities.Collections;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class CollectionMappingProfile : Profile
{
    public CollectionMappingProfile()
    {
        CreateMap<CollectionFilter, CollectionFilterDto>();
        CreateMap<CollectionFilterDto, CollectionFilter>();

        CreateMap<CreateCollectionCommand, Collection>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.ImageUrl, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.Filters, o => o.Ignore());

        CreateMap<UpdateCollectionCommand, Collection>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.ImageUrl, o => o.Ignore())
            .ForMember(d => d.Category, o => o.Ignore())
            .ForMember(d => d.Filters, o => o.Ignore());

        CreateMap<Collection, CollectionCardDto>()
            .ForMember(d => d.ImageUrl,
                o => o.MapFrom<CollectionImageUrlResolver>());

        CreateMap<Collection, CollectionDetailsDto>();
        CreateMap<CollectionDetailsDto, Collection>()
            .ForMember(d => d.Category, o => o.Ignore());
    }
}