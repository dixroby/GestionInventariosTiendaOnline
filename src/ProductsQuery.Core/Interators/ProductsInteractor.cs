﻿
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

    public async Task GetProductByNameAndCategory(ProductsDto request)
    {
        var Result =
                await repository
                .GetProductByNameAndCategory(request);
        
        await presenter.HandleResultAsync(Result);
    }
}