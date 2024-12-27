

namespace UserCommand.Repositories.Command;

internal class ProductsRepository (ProductsContext context) : IProductsRepository
{
    public async Task CreateProducts(ProductsDto request)
    {
        if (request.QuantityInventory < 0)
            throw new Exception("No se pueda ingresar un producto con cantidad negativa.");

        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            QuantityInventory = request.QuantityInventory
        };

        context.Products.Add(product);
        await context.SaveChangesAsync();
    }
}