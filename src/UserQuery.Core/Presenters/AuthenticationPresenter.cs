using UserQuery.BusinessObjects.Options;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Presenters;

internal class AuthenticationPresenter(IOptions<UsersOptions> options) : IAuthenticationOutputPort
{
    public LoginResponseDto LoginResponse { get; private set; }

    public async Task HandleResultAsync(LoginResponseDto login)
    {
        LoginResponse = login;

        await Task.CompletedTask;
    }
}