

namespace UserCommand.BusinessObjects.Interfaces
{
    public interface IProductsRepository
    {
        Task CreateProducts(ProductsDto request);
    }
}