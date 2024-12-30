namespace UserQuery.BusinessObjects.Interfaces;

public interface IAuthenticationOutputPort
{
    public LoginResponseDto LoginResponse { get; }
    public Task HandleResultAsync(LoginResponseDto login);
}