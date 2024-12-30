

namespace UserCommand.BusinessObjects.Interfaces
{
    public interface IUsersRepository
    {
        Task CreateProducts(UserDto request);
    }
}