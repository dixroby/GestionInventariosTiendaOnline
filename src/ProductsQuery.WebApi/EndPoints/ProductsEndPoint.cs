namespace ProductsQuery.WebApi.EndPoints;

public static class ProductsEndPoint
{
    public static IEndpointRouteBuilder MapProductskEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(Endpoints.GetProducts, async (IProductsController controller)
        => TypedResults.Ok(await controller.GetProductsAsync()));

        return app;
    }
}