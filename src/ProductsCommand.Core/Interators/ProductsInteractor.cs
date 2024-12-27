
namespace ProductsCommand.Core.Interators;

internal class ProductsInteractor(IProductsRepository repository) : IProductsInputPort
{
    public async Task CreateProductsAsync(ProductsDto request)
    {
        await 
            repository
            .CreateProducts(request);
    }

    public async Task DeleteProductsAsync(ProductsDto request)
    {
        await
            repository
            .DeleteProducts(request);
    }
}