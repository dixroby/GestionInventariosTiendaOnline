using ProductsCommand.Entities.Dtos;

namespace ProductsCommand.BusinessObjects.Interfaces
{
    public interface IProductsRepository
    {
        Task CreateProducts(ProductsDto request);
        Task DeleteProducts(ProductsDto request);
    }
}