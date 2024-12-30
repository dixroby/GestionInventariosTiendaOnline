namespace ProductsCommand.BusinessObjects.Interfaces;

public interface IProductsInputPort
{
    Task CreateProductsAsync(ProductsDto request);
    Task DeleteProductsAsync(ProductsDto request);
}