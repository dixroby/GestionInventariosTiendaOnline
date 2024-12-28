namespace UserQuery.BusinessObjects.Interfaces.User;

public interface IUserController
{
    public Task<IEnumerable<UserDto>> GetUserAsync();
}
