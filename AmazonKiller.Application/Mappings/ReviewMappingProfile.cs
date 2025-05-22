using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;


namespace AmazonKiller.Application.Mappings;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<Review, ReviewDto>()
            .ForMember(d => d.Likes, o => o.MapFrom(s => s.LikesFromUsers.Count))
            .ForMember(d => d.UserFullName, o => o.MapFrom(s => s.User.FirstName + " " + s.User.LastName))
            .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name));
    }
}