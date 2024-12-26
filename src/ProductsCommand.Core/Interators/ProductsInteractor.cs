namespace ProductsCommand.Core.Interators;

internal class ProductsInteractor(IProductsRepository repository,
                                  IProductsOutputPort presenter) : IProductsInputPort
{
    public async Task GetProductsAsync()
    {
        var Result =
            await repository
            .GetProductsSortedByDescendingPriceAsync();

        await presenter.HandleResultAsync(Result);
    }
}