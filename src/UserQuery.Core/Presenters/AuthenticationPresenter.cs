using UserQuery.BusinessObjects.Interfaces.User;
using UserQuery.BusinessObjects.Options;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Presenters;

internal class AuthenticationPresenter(IOptions<UsersOptions> options): IAuthenticationOutputPort
{
    public string Token { get; private set; }


    public Task HandleResultAsync(string token)
    {
        Token = token;

        return Task.CompletedTask;
    }
}