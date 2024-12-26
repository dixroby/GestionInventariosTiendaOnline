using ProductsCommand.Entities.Dtos;

namespace ProductsCommand.BusinessObjects.Interfaces;
public interface IProductsOutputPort
{
    IEnumerable<ProductsDto> Products { get; }
    Task HandleResultAsync(IEnumerable<ProductsDto> products);
}