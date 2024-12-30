namespace ProductsCommand.Core.Tests.Controllers;

public class ProductsControllerTests
{
    [Fact]
    public async Task CreateProductsAsync_ShouldInvokeInputPortAndCreateProduct()
    {
        // Arrange
        var inputPort = Substitute.For<IProductsInputPort>();
        var outputPort = Substitute.For<IProductsOutputPort>();

        var product = new ProductsDto(
            id: 1,
            name: "Arroz",
            description: "Arroz blanco de grano largo, ideal para acompañar tus comidas.",
            price: 3.99,
            category: "Granos",
            quantityInventory: 10
        );


        inputPort.CreateProductsAsync(product).Returns(Task.CompletedTask);

        var controller = new ProductsController(inputPort, outputPort);

        // Act
        await controller.CreateProductsAsync(product);

        // Assert
        await inputPort.Received(1).CreateProductsAsync(product);
    }

}
