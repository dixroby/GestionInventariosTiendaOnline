namespace UserQuery.BusinessObjects.Interfaces.User;
public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetUserSortedByDescendingPriceAsync();
    Task<UserDto> FindUserByUserNameAsync(string userName);
}