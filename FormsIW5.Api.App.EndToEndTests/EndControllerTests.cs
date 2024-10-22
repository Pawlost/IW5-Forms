﻿using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.App.EndToEndTests;

public class EndControllerTests : IAsyncDisposable
{
    private readonly FormsIW5ApiApplicationFactory application;
    private readonly Lazy<HttpClient> client;

    public EndControllerTests()
    {
        application = new FormsIW5ApiApplicationFactory();
        client = new Lazy<HttpClient>(application.CreateClient());
    }

    [Fact]
    public void Test1()
    {
        var test = Environment.GetEnvironmentVariable("MY_ENV_VAR");

        Assert.NotNull(test);
        Assert.Equal("printOverhere", test);
    }

    public async ValueTask DisposeAsync()
    {
        await application.DisposeAsync();
    }
}
