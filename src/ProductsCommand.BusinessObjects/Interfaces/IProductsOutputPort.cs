using ProductsCommand.Entities.Dtos;

namespace ProductsCommand.BusinessObjects.Interfaces;

public interface IProductsOutputPort
{
    Task HandleResultAsync();
}