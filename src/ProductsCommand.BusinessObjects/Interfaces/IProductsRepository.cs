using ProductsCommand.Entities.Dtos;

namespace ProductsCommand.BusinessObjects.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<ProductsDto>> GetProductsSortedByDescendingPriceAsync();
    }
}