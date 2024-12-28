using UserQuery.BusinessObjects.Options;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Presenters;

internal class UsersPresenter(IOptions<UsersOptions> options): IUserOutputPort
{
    public IEnumerable<UserDto> User { get; private set; }

    public Task HandleResultAsync(IEnumerable<UserDto> products)
    {
        User = 
            products
            .Select(s => new UserDto(s.Id,
                                     s.UserName,
                                     s.Role)
            );

        return Task.CompletedTask;
    }
}