using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.SendGrid.HttpClients.Registrars;
using Soenneker.SendGrid.OpenApiClientUtil.Abstract;

namespace Soenneker.SendGrid.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class SendGridOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="SendGridOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSendGridOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSendGridOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISendGridOpenApiClientUtil, SendGridOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="SendGridOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSendGridOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSendGridOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISendGridOpenApiClientUtil, SendGridOpenApiClientUtil>();

        return services;
    }
}
