using AmazonKillerBack.Application.DTOs;
using AmazonKillerBack.Application.Features.Products.Create;
using AmazonKillerBack.Domain.Entities;
using AutoMapper;

namespace AmazonKillerBack.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductCommand, Product>();
    }
}