namespace ProductsCommand.Repositories.Query;

internal class ProductsRepository (ProductsContext context) : IProductsRepository
{
    public async Task<IEnumerable<ProductsDto>> GetProductsSortedByDescendingPriceAsync()
    =>  await 
        context
        .Products
        .OrderByDescending(s => s.Price)
        .Select(s => new ProductsDto(s.Id,
                                     s.Name,
                                     s.Description,
                                     s.Price,
                                     s.Category,
                                     s.QuantityInventory))
        .ToListAsync();
}