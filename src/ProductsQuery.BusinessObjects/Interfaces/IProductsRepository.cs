namespace ProductsQuery.BusinessObjects.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<ProductsDto>> GetProductsSortedByDescendingPriceAsync();
    }
}