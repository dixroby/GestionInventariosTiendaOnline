namespace UserCommand.Core.Controllers;

internal class UsersController(IUsersInputPort inputPort,
                                  IUsersOutputPort presenter): IUsersController
{
    public async Task CreateProductsAsync(UserDto request)
    {
        await inputPort.CreateProductsAsync(request);
    }

}