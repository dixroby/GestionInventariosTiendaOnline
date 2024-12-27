namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IProductsInputPort, ProductsInteractor>();
        services.AddScoped<IProductsOutputPort, ProductsPresenter>();
        services.AddScoped<IProductsController, ProductsController>();

        return services;
    }
}