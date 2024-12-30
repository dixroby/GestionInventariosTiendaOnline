namespace UserQuery.BusinessObjects.Interfaces.Authentication;

public interface IAuthenticationController
{
    Task<LoginResponseDto> AuthenticateAsync(string username);
}