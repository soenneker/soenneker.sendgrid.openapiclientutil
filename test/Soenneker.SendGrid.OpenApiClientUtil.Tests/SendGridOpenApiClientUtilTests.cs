using Soenneker.SendGrid.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.SendGrid.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class SendGridOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ISendGridOpenApiClientUtil _openapiclientutil;

    public SendGridOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ISendGridOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
