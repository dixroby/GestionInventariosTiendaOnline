using Microsoft.AspNetCore.Mvc;
using ProductsQuery.Entities.Dtos;

namespace ProductsQuery.WebApi.EndPoints;

public static class ProductsEndPoint
{
    public static IEndpointRouteBuilder MapProductsEndPoint(this IEndpointRouteBuilder app)
    {
        app
            .MapGet(Endpoints.GetProducts, async (IProductsController controller)
            =>  TypedResults.
                Ok(await controller.GetProductsAsync()));

        app
            .MapGet(Endpoints.GetProductByNameAndCategory, async (IProductsController controller, [FromQuery] ProductsDto request)
            =>  TypedResults
                .Ok(await controller.GetProductByNameAndCategory(request)));


        return app;
    }
}