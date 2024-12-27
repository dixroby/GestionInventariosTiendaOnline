namespace UserCommand.BusinessObjects.Interfaces;

public interface IProductsInputPort
{
    Task CreateProductsAsync(ProductsDto request);
}