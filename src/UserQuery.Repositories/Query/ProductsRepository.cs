using UserQuery.BusinessObjects;

namespace UserQuery.Repositories.Query;

internal class ProductsRepository (ProductsContext context) : IUserRepository
{
    public async Task<IEnumerable<UserDto>> GetUserSortedByDescendingPriceAsync()
    =>  await
        context
        .Products
        .OrderByDescending(s => s.Role)
        .Select(s => 
            new UserDto(s.Id,
                        s.UserName,
                        s.Role)
        )
        .ToListAsync();
}