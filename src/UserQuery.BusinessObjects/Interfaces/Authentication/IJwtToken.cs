namespace UserQuery.BusinessObjects.Interfaces.Authentication;

public interface IJwtToken
{
    string GenerateJwtToken(UserDto user);
}
