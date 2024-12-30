namespace UserQuery.Entities.Dtos;

public class LoginResponseDto(string token,
                              string role)
{
    public string Token => token;
    public string Role => role;
}