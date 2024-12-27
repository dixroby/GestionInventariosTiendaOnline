using UserCommand.Entities.Dtos;

namespace UserCommand.BusinessObjects.Interfaces;

public interface IProductsOutputPort
{
    Task HandleResultAsync();
}