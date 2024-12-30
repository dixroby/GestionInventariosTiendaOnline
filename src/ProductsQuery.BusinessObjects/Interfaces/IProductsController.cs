namespace ProductsQuery.BusinessObjects.Interfaces;

public interface IProductsController
{
    public Task<IEnumerable<ProductsDto>> GetProductsAsync();
    public Task<IEnumerable<ProductsDto>> GetProductByNameAndCategory(ProductsDto request);
}
