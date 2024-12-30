using UserCommand.Entities.Dtos;

namespace UserCommand.BusinessObjects.Interfaces;

public interface IUsersOutputPort
{
    Task HandleResultAsync();
}