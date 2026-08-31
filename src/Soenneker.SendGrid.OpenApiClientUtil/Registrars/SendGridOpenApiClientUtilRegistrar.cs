using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.SendGrid.HttpClients.Registrars;
using Soenneker.SendGrid.OpenApiClientUtil.Abstract;

namespace Soenneker.SendGrid.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the lazily initialized SendGrid v3 API client.
/// </summary>
public static class SendGridOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds the SendGrid API client utility as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddSendGridOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddSendGridOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ISendGridOpenApiClientUtil, SendGridOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds the SendGrid API client utility as a scoped service backed by the singleton HTTP client provider. <para/>
    /// </summary>
    public static IServiceCollection AddSendGridOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddSendGridOpenApiHttpClientAsSingleton()
                .TryAddScoped<ISendGridOpenApiClientUtil, SendGridOpenApiClientUtil>();

        return services;
    }
}
