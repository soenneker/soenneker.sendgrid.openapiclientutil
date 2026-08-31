using Soenneker.SendGrid.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.SendGrid.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily initialized SendGrid v3 API client.
/// </summary>
public interface ISendGridOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SendGridOpenApiClient> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    new void Dispose();

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    new ValueTask DisposeAsync();
}
