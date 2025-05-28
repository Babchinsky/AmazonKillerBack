using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Mappings.ImageUrlResolvers;
using AmazonKiller.Application.Mappings.ImageUrlResolvers.Users;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;

namespace AmazonKiller.Application.Mappings;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<Review, ReviewDto>()
            .ForMember(d => d.ImageUrls, o => o.MapFrom<ReviewImageUrlResolver>())
            .ForMember(d => d.Likes, o => o.MapFrom(s => s.LikesFromUsers.Count))
            .ForMember(d => d.UserFullName, o => o.MapFrom(s =>
                !string.IsNullOrWhiteSpace(s.User.FirstName) || !string.IsNullOrWhiteSpace(s.User.LastName)
                    ? $"{s.User.FirstName} {s.User.LastName}".Trim()
                    : s.User.Email))
            .ForMember(d => d.UserImageUrl, o => o.MapFrom<ReviewUserImageUrlResolver>())
            .ForMember(d => d.RowVersion, o => o.MapFrom(s => Convert.ToBase64String(s.RowVersion)));
    }
}