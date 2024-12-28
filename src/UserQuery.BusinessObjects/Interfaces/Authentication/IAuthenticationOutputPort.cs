namespace UserQuery.BusinessObjects.Interfaces;

public interface IAuthenticationOutputPort
{
    public string Token { get; }
    public Task HandleResultAsync(string token);
}