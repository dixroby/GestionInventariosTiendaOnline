namespace UserCommand.BusinessObjects.Interfaces;

public interface IUsersController
{
    public Task CreateProductsAsync(UserDto request);
}