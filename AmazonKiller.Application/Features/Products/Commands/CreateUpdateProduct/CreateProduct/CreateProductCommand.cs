using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.CreateUpdateProduct.CreateProduct;

public class CreateProductCommand : UpsertProductModel, IRequest<ProductDto>;