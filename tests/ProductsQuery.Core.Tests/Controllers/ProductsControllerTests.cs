using NSubstitute;
using ProductsQuery.BusinessObjects.Interfaces;

namespace ProductsCommand.Core.Tests.Controllers;

public class ProductsControllerTests
{
    [Fact]
    public async Task ProductsAsync_ShouldInvokeInputPortAndReturnProducts()
    {
        // Arrange
        var inputPort = Substitute.For<IProductsInputPort>();
        var outputPort = Substitute.For<IProductsOutputPort>();

        var products = new List<ProductsDto>
        {
            new ProductsDto(
                id: 1,
                name: "Arroz",
                description: "Arroz blanco de grano largo, ideal para acompañar tus comidas.",
                price: 3.99,
                category: "Granos",
                quantityInventory: 10),

            new ProductsDto(
                id: 2,
                name: "Frijoles Negros",
                description: "Frijoles negros secos, perfectos para preparar guisos y ensaladas.",
                price: 2.99,
                category: "Legumbres",
                quantityInventory: 20),

            new ProductsDto(
                id: 3,
                name: "Aceite de Oliva",
                description: "Aceite de oliva extra virgen para aderezar ensaladas y cocinar.",
                price: 5.49,
                category: "Aceites",
                quantityInventory: 15)
        };

        outputPort.Products.Returns(products);
        inputPort.GetProductsAsync().Returns(Task.CompletedTask);

        var Controller = new ProductsController(inputPort, outputPort);

        // Act
        var ReturnedSpecials = await Controller.GetProductsAsync();

        // Assert
        await inputPort.Received(1).GetProductsAsync();
        Assert.Equal(products, ReturnedSpecials);
    }
}
