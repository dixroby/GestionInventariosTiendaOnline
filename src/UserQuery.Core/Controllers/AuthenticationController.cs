using UserQuery.BusinessObjects.Interfaces.Authentication;
using UserQuery.Entities.Dtos;

namespace UserQuery.Core.Controllers;
internal class AuthenticationController(IAuthenticationInputPort inputPort,
                                        IAuthenticationOutputPort presenter) : IAuthenticationController
{
    public async Task<LoginResponseDto> AuthenticateAsync(string username)
    {
        await inputPort.AuthenticateAsync(username);
        return presenter.LoginResponse;
    }
}