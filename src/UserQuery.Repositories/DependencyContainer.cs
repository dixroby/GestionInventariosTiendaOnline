﻿using Microsoft.Extensions.Hosting;
using UserQuery.BusinessObjects.Interfaces.User;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositoriesServices(this IServiceCollection services,
                                                             Action<DBOptions> configureProductsDBOptions)
    {
        services.AddDbContext<ProductsContext>();
        services.AddScoped<IUserRepository, ProductsRepository>();

        services.Configure(configureProductsDBOptions);

        return services;
    }

    public static IHost InitializeDB(this IHost app)
    {
        using IServiceScope Scope = app.Services.CreateScope();

        var Context = 
            Scope
            .ServiceProvider
            .GetRequiredService<ProductsContext>();

        Context.Database.EnsureCreated();

        return app;
    }
}