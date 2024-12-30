namespace UserCommand.BusinessObjects.Interfaces;

public interface IUsersInputPort
{
    Task CreateProductsAsync(UserDto request);
}