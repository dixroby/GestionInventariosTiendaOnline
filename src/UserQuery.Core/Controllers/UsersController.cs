using UserQuery.BusinessObjects.Interfaces.User;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Controllers;

internal class UsersController(IUserInputPort inputPort,
                               IUserOutputPort presenter): IUserController
{
    public async Task<IEnumerable<UserDto>> GetUserAsync()
    {
        await inputPort.GetUserAsync();
        return presenter.User;
    }
}