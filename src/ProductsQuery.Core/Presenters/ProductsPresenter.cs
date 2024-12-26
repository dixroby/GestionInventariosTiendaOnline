namespace ProductsQuery.Core.Presenters;

internal class ProductsPresenter(IOptions<ProductsOptions> options): IProductsOutputPort
{
    public IEnumerable<ProductsDto> Products { get; private set; }

    public Task HandleResultAsync(IEnumerable<ProductsDto> products)
    {
        Products = 
            products
            .Select(s => new ProductsDto(s.Id,
                                         s.Name,
                                         s.Description,
                                         s.Price,
                                         s.Category,
                                         s.QuantityInventory));

        return Task.CompletedTask;
    }
}