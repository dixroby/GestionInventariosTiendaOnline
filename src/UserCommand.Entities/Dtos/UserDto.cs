namespace UserCommand.Entities.Dtos;

public class UserDto(int id,
                     string userName,
                     string role)
{
    public int Id => id;
    public string UserName => userName;
    public string Role => role;
}
