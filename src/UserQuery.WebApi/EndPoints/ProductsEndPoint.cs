using UserQuery.Entities.ValueObjects;

namespace UserQuery.WebApi.EndPoints;

public static class ProductsEndPoint
{
    public static IEndpointRouteBuilder MapProductskEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(Endpoints.GetUsers, async (IUserController controller)
        => TypedResults.Ok(await controller.GetUserAsync()));

        return app;
    }
}