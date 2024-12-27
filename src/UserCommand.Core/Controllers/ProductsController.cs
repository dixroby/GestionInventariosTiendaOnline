namespace UserCommand.Core.Controllers;

internal class ProductsController(IProductsInputPort inputPort,
                                  IProductsOutputPort presenter): IProductsController
{
    public async Task CreateProductsAsync(ProductsDto request)
    {
        await inputPort.CreateProductsAsync(request);
    }

}