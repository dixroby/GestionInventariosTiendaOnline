using UserQuery.BusinessObjects.Interfaces.Authentication;
using UserQuery.BusinessObjects.Interfaces.User;
using UserQuery.BusinessObjects.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
                                                 Action<UsersOptions> configureProductsOptions)
    {
        services.AddScoped<IUserInputPort, UsersInteractor>();
        services.AddScoped<IUserOutputPort, UsersPresenter>();
        services.AddScoped<IUserController, UsersController>();

        services.AddSingleton<IUserCache, UsersCache>();

        services.AddScoped<IAuthenticationInputPort, AuthenticationInteractor>();
        services.AddScoped<IAuthenticationOutputPort, AuthenticationPresenter>();
        services.AddScoped<IAuthenticationController, AuthenticationController>();

        services.Configure(configureProductsOptions);

        return services;
    }
}
