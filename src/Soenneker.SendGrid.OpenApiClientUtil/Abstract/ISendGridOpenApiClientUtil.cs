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
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SendGridOpenApiClient> Get(CancellationToken cancellationToken = default);
}
