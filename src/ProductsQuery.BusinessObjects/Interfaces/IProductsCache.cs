namespace ProductsQuery.BusinessObjects.Interfaces;
public interface IProductsCache
{
    Task SetProductsAsync(IEnumerable<ProductsDto> products);
    Task<IEnumerable<ProductsDto>> GetProductsAsync();
}