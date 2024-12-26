using ProductsCommand.BusinessObjects.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
                                                 Action<ProductsOptions> configureProductsOptions)
    {
        services.AddScoped<IProductsInputPort, ProductsInteractor>();
        services.AddScoped<IProductsOutputPort, ProductsPresenter>();
        services.AddScoped<IProductsController, ProductsController>();
        services.AddSingleton<IProductsCache, ProductsCache>();

        services.Configure(configureProductsOptions);

        return services;
    }
}
