namespace ProductsQuery.Core.Controllers;

internal class ProductsController(IProductsInputPort inputPort,
                                  IProductsOutputPort presenter): IProductsController
{
    public async Task<IEnumerable<ProductsDto>> GetProductsAsync()
    {
        await inputPort.GetProductsAsync();
        return presenter.Products;
    }

    public async Task<IEnumerable<ProductsDto>> GetProductByNameAndCategory(ProductsDto request)
    {
        await inputPort.GetProductByNameAndCategory(request);
        return presenter.Products;
    }
}