namespace UserQuery.BusinessObjects.Interfaces.User;
public interface IUserOutputPort
{
    IEnumerable<UserDto> User { get; }
    Task HandleResultAsync(IEnumerable<UserDto> user);
}