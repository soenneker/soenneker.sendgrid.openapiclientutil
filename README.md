[![](https://img.shields.io/nuget/v/soenneker.sendgrid.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sendgrid.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sendgrid.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.sendgrid.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.SendGrid.OpenApiClientUtil

Provides a lazily initialized SendGrid client for mail, contacts, lists, templates, suppressions, statistics, settings, webhooks, API keys, and account resources.

## Installation

```bash
dotnet add package Soenneker.SendGrid.OpenApiClientUtil
```

## Configuration

```json
{
  "SendGrid": {
    "ApiKey": "SG.xxxxxxxxx"
  }
}
```

## Usage

```csharp
using Soenneker.SendGrid.OpenApiClientUtil.Abstract;
using Soenneker.SendGrid.OpenApiClientUtil.Registrars;

services.AddSendGridOpenApiClientUtilAsSingleton();

public sealed class SendGridScopeReader
{
    private readonly ISendGridOpenApiClientUtil _sendGrid;

    public SendGridScopeReader(ISendGridOpenApiClientUtil sendGrid)
    {
        _sendGrid = sendGrid;
    }

    public async Task GetScopes(CancellationToken cancellationToken)
    {
        var client = await _sendGrid.Get(cancellationToken);
        var scopes = await client.Tsg_scopes_v3.V3.Scopes
            .WithUrl("https://api.sendgrid.com/v3/scopes")
            .GetAsync(cancellationToken: cancellationToken);
    }
}
```

The source schema's `tsg_*` group names appear in generated URL templates even though they are not public SendGrid route segments. Use `WithUrl` with the documented `https://api.sendgrid.com/v3/...` endpoint for these builders.

Use `AddSendGridOpenApiClientUtilAsScoped()` when each scope should have its own lazily initialized generated client. Both registrations reuse the singleton authenticated HTTP client provider.
