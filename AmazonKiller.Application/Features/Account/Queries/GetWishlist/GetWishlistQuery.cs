using MediatR;
using AmazonKiller.Application.DTOs.Account;

namespace AmazonKiller.Application.Features.Account.Queries.GetWishlist;

public record GetWishlistQuery : IRequest<List<ProductInWishlistDto>>;