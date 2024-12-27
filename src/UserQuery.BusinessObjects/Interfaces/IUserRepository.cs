namespace UserQuery.BusinessObjects;
public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetUserSortedByDescendingPriceAsync();
}