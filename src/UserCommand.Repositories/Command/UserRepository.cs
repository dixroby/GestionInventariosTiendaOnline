namespace UserCommand.Repositories.Command;

internal class UserRepository(ProductsContext context) : IUsersRepository
{
    public async Task CreateProducts(UserDto request)
    {
        var user = new User
        {
            UserName = request.UserName,
            Role = request.Role,
        };

        context.User.Add(user);
        await context.SaveChangesAsync();
    }
}