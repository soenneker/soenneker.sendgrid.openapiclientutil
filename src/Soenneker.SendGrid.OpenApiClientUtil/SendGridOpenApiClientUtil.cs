using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.SendGrid.HttpClients.Abstract;
using Soenneker.SendGrid.OpenApiClientUtil.Abstract;
using Soenneker.SendGrid.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.SendGrid.OpenApiClientUtil;

///<inheritdoc cref="ISendGridOpenApiClientUtil"/>
public sealed class SendGridOpenApiClientUtil : ISendGridOpenApiClientUtil
{
    private readonly AsyncSingleton<SendGridOpenApiClient> _client;

    public SendGridOpenApiClientUtil(ISendGridOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<SendGridOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("SendGrid:ApiKey");
            string authHeaderValueTemplate = configuration["SendGrid:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new SendGridOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<SendGridOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
