namespace ProductsQuery.Core.Interators;

internal class ProductsInteractor(IProductsRepository repository,
                                  IProductsOutputPort presenter,
                                  IProductsCache cache): IProductsInputPort
{
    public async Task GetProductsAsync()
    {
        var Result = await cache.GetProductsAsync();

        if (Result == null)
        {
            Result = 
                await repository
                .GetProductsSortedByDescendingPriceAsync();

            await cache.SetProductsAsync(Result);
        }
        await presenter.HandleResultAsync(Result);
    }
}