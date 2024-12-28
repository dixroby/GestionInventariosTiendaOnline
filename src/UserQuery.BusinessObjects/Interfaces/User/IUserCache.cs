namespace UserQuery.BusinessObjects.Interfaces.User;
public interface IUserCache
{
    Task SetUserAsync(IEnumerable<UserDto> user);
    Task<IEnumerable<UserDto>> GetUsersAsync();
}