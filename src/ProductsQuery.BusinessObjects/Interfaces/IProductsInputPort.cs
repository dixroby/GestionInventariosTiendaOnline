namespace ProductsQuery.BusinessObjects.Interfaces;

public interface IProductsInputPort
{
    Task GetProductsAsync();
    Task GetProductByNameAndCategory(ProductsDto request);
}
