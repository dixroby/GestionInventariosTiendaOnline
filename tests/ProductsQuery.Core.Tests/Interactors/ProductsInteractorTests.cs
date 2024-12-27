namespace ProductsCommand.Core.Tests.Interactors;

public class ProductsInteractorTests
{
    [Fact]
    public async Task ProductsAsync__ShouldInvokeHandleResultAsync_WithProducts()
    {
        // Arrange
        var Repository = Substitute.For<IProductsRepository>();
        var Presenter = Substitute.For<IProductsOutputPort>();
        var Cache = Substitute.For<IProductsCache>();

        var Interactor = new ProductsInteractor(Repository, Presenter, Cache);

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

        Cache.GetProductsAsync().Returns(products);

        Repository
            .GetProductsSortedByDescendingPriceAsync()
            .Returns(products);

        // Act
        await Interactor.GetProductsAsync();

        // Assert
        await 
            Presenter
            .Received(1)
            .HandleResultAsync(Arg.Is<IEnumerable<ProductsDto>>(specials => specials == products));
    }

    [Fact]
    public async Task ProductsAsync_Should_GetFromCache_When_CacheHasData()
    {
        // Arrange
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

        var Repository = Substitute.For<IProductsRepository>();
        var Presenter = Substitute.For<IProductsOutputPort>();
        var Cache = Substitute.For<IProductsCache>();

        Cache.GetProductsAsync().Returns(products);

        var Interactor = new ProductsInteractor(Repository, Presenter, Cache);

        // Act
        await Interactor.GetProductsAsync();

        // Assert
        await 
            Cache
            .Received(1)
            .GetProductsAsync();
        
        await 
            Repository
            .DidNotReceive()
            .GetProductsSortedByDescendingPriceAsync();
    }

    [Fact]
    public async Task ProductsAsync_Should_GetFromRepository_When_CacheIsEmpty()
    {
        // Arrange
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

        var Repository = Substitute.For<IProductsRepository>();
        var Presenter = Substitute.For<IProductsOutputPort>();
        var Cache = Substitute.For<IProductsCache>();

        Cache
            .GetProductsAsync()
            .Returns((IEnumerable<ProductsDto>)null);

        Repository
            .GetProductsSortedByDescendingPriceAsync()
            .Returns(products);

        var Interactor = new ProductsInteractor(Repository, Presenter, Cache);

        // Act
        await Interactor.GetProductsAsync();

        // Assert
        await Cache.Received(1).GetProductsAsync();
        await Repository.Received(1).GetProductsSortedByDescendingPriceAsync();
        await Cache.Received(1).SetProductsAsync(products);
    }
}