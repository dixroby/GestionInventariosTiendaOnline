namespace ProductsQuery.BusinessObjects.Interfaces
{
    internal interface IProductsController
    {
        Task<IEnumerable<ProductsDto>> GetSpecialsAsync();
    }
}
