namespace ProductsCommand.BusinessObjects.Interfaces;

public interface IProductsController
{
    public Task<IEnumerable<ProductsDto>> GetProductsAsync();
}
