using Microsoft.AspNetCore.Mvc;

namespace ProductsCommand.WebApi.EndPoints
{
    public static class ProductsEndPoint
    {
        public static IEndpointRouteBuilder MapProductskEndPoint(this IEndpointRouteBuilder app)
        {
            app.MapPost(Endpoints.CreateProducts, async (IProductsController controller, [FromBody] ProductsDto request) =>
            {
                try
                {
                    await controller.CreateProductsAsync(request);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            });

            app.MapPost(Endpoints.DeleteProducts, async (IProductsController controller, [FromBody] ProductsDto request) =>
            {
                try
                {
                    await controller.DeleteProductsAsync(request);
                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.InternalServerError(ex.Message);
                }
            });


            return app;
        }
    }
}
