namespace ProductsCommand.BusinessObjects.Interfaces;

public interface IProductsController
{
    public Task CreateProductsAsync(ProductsDto request);
    public Task DeleteProductsAsync(ProductsDto productId);
}