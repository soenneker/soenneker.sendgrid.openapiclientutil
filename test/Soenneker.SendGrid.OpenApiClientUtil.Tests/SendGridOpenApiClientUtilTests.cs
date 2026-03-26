using Soenneker.SendGrid.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.SendGrid.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class SendGridOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ISendGridOpenApiClientUtil _openapiclientutil;

    public SendGridOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ISendGridOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
