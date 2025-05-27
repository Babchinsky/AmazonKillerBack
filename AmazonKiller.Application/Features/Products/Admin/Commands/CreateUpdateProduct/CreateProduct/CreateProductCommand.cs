using AmazonKiller.Application.DTOs.Products;
using AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.Common;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Admin.Commands.CreateUpdateProduct.CreateProduct;

public class CreateProductCommand : UpsertProductModel, IRequest<ProductDto>;