using UserQuery.BusinessObjects;

namespace UserQuery.Repositories.Query;

internal class ProductsRepository (ProductsContext context) : IUserRepository
{
    public async Task<IEnumerable<UserDto>> GetUserSortedByDescendingPriceAsync()
    =>  await
        context
        .Products
        .OrderByDescending(s => s.Price)
        .Select(s => new UserDto(s.Id,
                                     s.Name,
                                     s.Description,
                                     s.Price,
                                     s.Category,
                                     s.QuantityInventory))
        .ToListAsync();
}