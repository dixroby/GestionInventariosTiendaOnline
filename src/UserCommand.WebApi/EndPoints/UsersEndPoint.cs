using Microsoft.AspNetCore.Mvc;
using UserCommand.Entities.ValueObjects;
using UserCommand.BusinessObjects.Interfaces;
using UserCommand.Entities.Dtos;

namespace UserCommand.WebApi.EndPoints;

public static class UsersEndPoint
{
    public static IEndpointRouteBuilder MapUsersEndPoint(this IEndpointRouteBuilder app)
    {
        app.MapPost(Endpoints.CreateUser, async (IUsersController controller, [FromBody] UserDto request) =>
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
        return app;
    }
}