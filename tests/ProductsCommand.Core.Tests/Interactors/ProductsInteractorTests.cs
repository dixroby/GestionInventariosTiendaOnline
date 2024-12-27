namespace ProductsCommand.Core.Tests.Interactors;

public class ProductsInteractorTests
{
    [Fact]
    public async Task CreateProductsAsync_ShouldInvokeHandleResultAsync_CreateProduct()
    {
        // Arrange
        var repository = Substitute.For<IProductsRepository>();
        var inputPort = new ProductsInteractor(repository);

        var product = new ProductsDto(
            id: 3,
            name: "Aceite de Oliva",
            description: "Aceite de oliva extra virgen para aderezar ensaladas y cocinar.",
            price: 5.49,
            category: "Aceites",
            quantityInventory: 15
        );

        repository.CreateProducts(product).Returns(Task.CompletedTask);

        // Act
        await inputPort.CreateProductsAsync(product);

        // Assert
        await repository.Received(1).CreateProducts(product);
    }


    [Fact]
    public async Task DeleteProductsAsync_ShouldInvokeHandleResultAsync_DeleteProduct()
    {
        // Arrange
        var repository = Substitute.For<IProductsRepository>();
        var inputPort = new ProductsInteractor(repository);

        var product = new ProductsDto(
            id: 3,
            name: "Aceite de Oliva",
            description: "Aceite de oliva extra virgen para aderezar ensaladas y cocinar.",
            price: 5.49,
            category: "Aceites",
            quantityInventory: 15
        );

        repository.CreateProducts(product).Returns(Task.CompletedTask);

        // Act
        await inputPort.CreateProductsAsync(product);

        // Assert
        await repository.Received(1).CreateProducts(product);
    }

}