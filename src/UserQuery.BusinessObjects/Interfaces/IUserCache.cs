namespace UserQuery.BusinessObjects.Interfaces;
public interface IUserCache
{
    Task SetUserAsync(IEnumerable<UserDto> user);
    Task<IEnumerable<UserDto>> GetUsersAsync();
}