namespace ProductsQuery.Repositories.Query;

internal class ProductsRepository (ProductsContext context) : IProductsRepository
{
    public async Task<IEnumerable<ProductsDto>> GetProductByNameAndCategory(ProductsDto request)
    => await
        context
        .Products
        .Where(x => 
            (x.Name == request.Name || string.IsNullOrEmpty(request.Name)) && 
            (x.Category == request.Category || string.IsNullOrEmpty(request.Category))
        )
        .OrderByDescending(s => s.Price)
        .Select(s => new ProductsDto(s.Id,
                                     s.Name,
                                     s.Description,
                                     s.Price,
                                     s.Category,
                                     s.QuantityInventory))
        .ToListAsync();

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