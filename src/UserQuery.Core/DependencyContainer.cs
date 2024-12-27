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

        services.Configure(configureProductsOptions);

        return services;
    }
}
