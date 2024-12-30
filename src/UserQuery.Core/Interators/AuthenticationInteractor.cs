using UserQuery.BusinessObjects.Interfaces.Authentication;
using UserQuery.BusinessObjects.Interfaces.User;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Interators;

internal class AuthenticationInteractor(IUserRepository repository,
                                        IAuthenticationOutputPort presenter,
                                        IJwtToken jwtToken) : IAuthenticationInputPort
{

    public async Task AuthenticateAsync(string username)
    {
        var Result =
            await
            repository
            .FindUserByUserNameAsync(username);

        if (Result == null)
            throw new Exception("Usuario no existe");

        var token = jwtToken.GenerateJwtToken(Result);

        var login = new LoginResponseDto(token, Result.Role);

        await presenter.HandleResultAsync(login);
    }
}