namespace ProductsQuery.Core.Controllers;

internal class ProductsController(IProductsInputPort inputPort,
                                  IProductsOutputPort presenter): IProductsController
{
    public async Task<IEnumerable<ProductsDto>> GetProductsAsync()
    {
        await inputPort.GetProductsAsync();
        return presenter.Products;
    }
}