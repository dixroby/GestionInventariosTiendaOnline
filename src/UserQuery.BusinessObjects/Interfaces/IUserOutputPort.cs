namespace UserQuery.BusinessObjects.Interfaces;
public interface IUserOutputPort
{
    IEnumerable<UserDto> User { get; }
    Task HandleResultAsync(IEnumerable<UserDto> user);
}