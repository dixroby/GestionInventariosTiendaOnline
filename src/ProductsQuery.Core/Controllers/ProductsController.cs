namespace ProductsQuery.Core.Controllers;

internal class ProductsController(IProductsInputPort inputPort,
                                  IProductsOutputPort presenter): IProductsController
{
    public async Task<IEnumerable<ProductsDto>> GetProductsAsync()
    {
        try
        {
            await inputPort.GetProductsAsync();
        }
        catch (Exception)
        {

            throw;
        }
        return presenter.Products;
    }

    public async Task<IEnumerable<ProductsDto>> GetProductByNameAndCategory(ProductsDto request)
    {
        try
        {
            await inputPort.GetProductByNameAndCategory(request);
        }
        catch (Exception)
        {

            throw;
        }
        return presenter.Products;
    }
}