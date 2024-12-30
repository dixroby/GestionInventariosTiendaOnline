using Microsoft.Extensions.Options;
using ProductsQuery.BusinessObjects.Options;
using ProductsQuery.Core.Presenters;
using ProductsQuery.Entities.Dtos;

namespace ProductsCommand.Core.Tests.Presenters
{
    public class ProductsPresenterTests
    {
        [Fact]
        public async Task HandlerResultAsync_Should_Set_Products()
        {
            // Arrange
            IOptions<ProductsOptions> productsOptions =
                Options
                .Create<ProductsOptions>(new ProductsOptions());

            var Presenter = new ProductsPresenter(productsOptions);

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

            // Act
            await Presenter.HandleResultAsync(products);

            // Assert
            Assert.Equal(products.Count, Presenter.Products.Count());
        }
    }
}