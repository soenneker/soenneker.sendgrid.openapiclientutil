using Soenneker.SendGrid.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.SendGrid.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ISendGridOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<SendGridOpenApiClient> Get(CancellationToken cancellationToken = default);
}
