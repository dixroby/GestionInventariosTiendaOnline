namespace UserQuery.WebApi.EndPoints;

public static class UsersEndPoint
{
    public static IEndpointRouteBuilder MapUsersEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapGet(Endpoints.GetUsers, async (IUserController controller) =>
            TypedResults.Ok(await controller.GetUserAsync()))
            .RequireAuthorization();

        return app;
    }

}