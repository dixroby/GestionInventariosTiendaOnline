namespace UserQuery.BusinessObjects.Interfaces;

public interface IAuthenticationInputPort
{
    Task AuthenticateAsync(string username);
}