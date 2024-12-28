using Microsoft.Extensions.Hosting;
using UserQuery.Authentication.Option;
using UserQuery.Authentication.Service;
using UserQuery.BusinessObjects.Interfaces.Authentication;
using UserQuery.BusinessObjects.Interfaces.User;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddJwtTokenServices(this IServiceCollection services,
                                                             Action<AuthenticationOption> configureAuthenticationOption)
    {
        services.AddScoped<IJwtToken, JwtToken>();
        services.Configure(configureAuthenticationOption);

        return services;
    }
}