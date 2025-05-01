using AmazonKiller.Application.DTOs.Admin.Users;
using AmazonKiller.Domain.Entities.Users;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class AdminUserMappingProfile : Profile
{
    public AdminUserMappingProfile()
    {
        CreateMap<User, UserAdminDto>()
            // строки → в читаемый текст
            .ForMember(d => d.Role, o => o.MapFrom(s => s.Role.ToString()))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
    }
}