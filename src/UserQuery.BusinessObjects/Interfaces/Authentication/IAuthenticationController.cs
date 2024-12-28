namespace UserQuery.BusinessObjects.Interfaces.Authentication;

public interface IAuthenticationController
{
    Task<string> AuthenticateAsync(string username);
}