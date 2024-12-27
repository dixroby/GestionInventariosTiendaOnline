namespace UserCommand.Core.Interators;

internal class ProductsInteractor(IProductsRepository repository) : IProductsInputPort
{
    public async Task CreateProductsAsync(ProductsDto request)
    {
        await
            repository
            .CreateProducts(request);
    }
}