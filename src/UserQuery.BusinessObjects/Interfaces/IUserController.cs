namespace UserQuery.BusinessObjects.Interfaces;

public interface IUserController
{
    public Task<IEnumerable<UserDto>> GetUserAsync();
}
