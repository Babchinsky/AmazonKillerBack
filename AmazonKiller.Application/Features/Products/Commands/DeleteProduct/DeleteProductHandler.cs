using AmazonKiller.Application.Interfaces.Repositories.Products;
using MediatR;

namespace AmazonKiller.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductHandler(IProductRepository repo)
    : IRequestHandler<DeleteProductCommand, bool>
{
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        if (!await repo.IsExistsAsync(request.Id))
            return false;

        await repo.DeleteAsync(request.Id);
        return true;
    }
}