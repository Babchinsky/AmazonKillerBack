using AmazonKiller.Application.DTOs.Users;
using AmazonKiller.Application.Mappings.ImageUrlResolvers.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserAdminDto>()
            .ForMember(d => d.Role, o => o.MapFrom(s => s.Role.ToString()))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));

        CreateMap<User, UserInfoDto>()
            .ForMember(d => d.ImageUrl, o => o.MapFrom<UserImageUrlResolver>());
    }
}