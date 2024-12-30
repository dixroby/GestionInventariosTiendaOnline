using UserQuery.BusinessObjects.Interfaces.User;

namespace UserQuery.Repositories.Query;

internal class ProductsRepository (ProductsContext context) : IUserRepository
{
    public async Task<UserDto> FindUserByUserNameAsync(string userName)
    => await
        context
        .User
        .Where(x => x.UserName == userName)
        .Select(s =>
            new UserDto(s.Id,
                        s.UserName,
                        s.Role)
        )
        .FirstOrDefaultAsync();

    public async Task<IEnumerable<UserDto>> GetUserSortedByDescendingPriceAsync()
    =>  await
        context
        .User
        .OrderByDescending(s => s.Role)
        .Select(s => 
            new UserDto(s.Id,
                        s.UserName,
                        s.Role)
        )
        .ToListAsync();
}