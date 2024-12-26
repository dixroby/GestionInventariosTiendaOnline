namespace ProductsCommand.Core.Tests.Cache;

public class ProductsCacheTests
{
    [Fact]
    public async Task SetProductsAsync_Should_Save_And_GetSpecialsAsync_Should_Return_Same_Value_From_Cache()
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


        var CacheOptions = Options.Create(new MemoryDistributedCacheOptions());
        IDistributedCache Cache = new MemoryDistributedCache(CacheOptions);

        ILogger<ProductsCache> Logger = new NullLogger<ProductsCache>();

        var productsCache = new ProductsCache(Cache, Logger);

        // Act
        await productsCache.SetProductsAsync(products);
        var Result = await productsCache.GetProductsAsync();

        // Assert
        Assert.Equal(products.Count, Result.Count());

        var Pairs = 
            products
            .Zip(Result, (expected, actual) =>  
                new { expected, actual }
             );

        Assert
            .All(Pairs, pair =>
                Assert.True(
                        pair.expected.Id == pair.actual.Id &&
                        pair.expected.Name == pair.actual.Name &&
                        pair.expected.Price == pair.actual.Price &&
                        pair.expected.Description == pair.actual.Description &&
                        pair.expected.Category == pair.actual.Category &&
                        pair.expected.QuantityInventory == pair.actual.QuantityInventory
                )
            );
    }
}