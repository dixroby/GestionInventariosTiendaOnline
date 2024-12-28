using UserQuery.BusinessObjects.Interfaces.Authentication;

namespace UserQuery.Core.Controllers;
internal class AuthenticationController(IAuthenticationInputPort inputPort,
                                        IAuthenticationOutputPort presenter) : IAuthenticationController
{
    public async Task<string> AuthenticateAsync(string username)
    {
        await inputPort.AuthenticateAsync(username);
        return presenter.Token;
    }
}