using AmazonKiller.Application.DTOs.Reviews;
using AmazonKiller.Application.Features.Reviews.Commands.CreateReview;
using AmazonKiller.Application.Features.Reviews.Commands.UpdateReview;
using AmazonKiller.Domain.Entities.Products;
using AmazonKiller.Domain.Entities.Reviews;
using AutoMapper;


namespace AmazonKiller.Application.Mappings;

public class ReviewMappingProfile : Profile
{
    public ReviewMappingProfile()
    {
        CreateMap<Review, ReviewDto>().ReverseMap();
        CreateMap<ReviewContent, ReviewContentDto>().ReverseMap();
        
        CreateMap<CreateReviewCommand, Review>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Likes, opt => opt.Ignore());
        
        CreateMap<UpdateReviewCommand, Review>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Likes, opt => opt.Ignore());
    }
}
