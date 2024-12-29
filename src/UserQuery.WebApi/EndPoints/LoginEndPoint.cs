namespace UserQuery.WebApi.EndPoints;

public static class LoginEndPoint
{
    public static IEndpointRouteBuilder MapLoginEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapPost(Endpoints.Login, async (IAuthenticationController controller, [FromBody] UserDto request) =>
        {
            try
            {
                var reulst = await controller.AuthenticateAsync(request.UserName);
                return Results.Ok(new { Token = reulst });
            }
            catch (Exception ex)
            {
                return Results.InternalServerError(ex.Message);
            }
        });

        return app;
    }
}