namespace UserCommand.Core.Interators;

internal class UsersInteractor(IUsersRepository repository) : IUsersInputPort
{
    public async Task CreateProductsAsync(UserDto request)
    {
        await
            repository
            .CreateProducts(request);
    }
}