namespace ProductsCommand.Core.Presenters;

internal class ProductsPresenter(): IProductsOutputPort
{
    public Task HandleResultAsync()
    {
        return Task.CompletedTask;
    }
}