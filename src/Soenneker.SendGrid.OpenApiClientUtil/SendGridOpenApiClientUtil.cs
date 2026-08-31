using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.SendGrid.HttpClients.Abstract;
using Soenneker.SendGrid.OpenApiClientUtil.Abstract;
using Soenneker.SendGrid.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.SendGrid.OpenApiClientUtil;

public sealed class SendGridOpenApiClientUtil : ISendGridOpenApiClientUtil
{
    private readonly AsyncSingleton<SendGridOpenApiClient> _client;

    public SendGridOpenApiClientUtil(ISendGridOpenApiHttpClient httpClientUtil, IConfiguration _)
    {
        _client = new AsyncSingleton<SendGridOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

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
