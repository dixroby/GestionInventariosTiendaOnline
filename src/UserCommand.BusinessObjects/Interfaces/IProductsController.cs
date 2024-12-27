namespace UserCommand.BusinessObjects.Interfaces;

public interface IProductsController
{
    public Task CreateProductsAsync(ProductsDto request);
}