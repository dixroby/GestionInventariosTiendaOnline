using ProductsCommand.BusinessObjects.Options;
using UserCommand.BusinessObjects.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
                                                 Action<UsersOptions> configureProductsOptions)
    {
        services.AddScoped<IUsersInputPort, UsersInteractor>();
        services.AddScoped<IUsersOutputPort, UsersPresenter>();
        services.AddScoped<IUsersController, UsersController>();

        return services;
    }
}