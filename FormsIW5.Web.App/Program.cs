using System;
using System.Globalization;
using AutoMapper.Internal;
using FormsIW5.Web.App;
using FormsIW5.Web.BL.Installer;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using FormsIW5.Common.Installer;

const string defaultCultureString = "cs";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

builder.Services.Install<WebBLInstaller>(builder.Configuration);

builder.Services.AddTransient<AuthorizationMessageHandler>();

builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri(apiBaseUrl))
    .AddHttpMessageHandler(serviceProvider
    => serviceProvider?.GetService<AuthorizationMessageHandler>()
        ?.ConfigureHandler(
            authorizedUrls: [apiBaseUrl],
            scopes: ["cookbookapi"]));

builder.Services.AddScoped<HttpClient>(serviceProvider => serviceProvider.GetService<IHttpClientFactory>().CreateClient("api"));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("IdentityServer", options.ProviderOptions);
    var configurationSection = builder.Configuration.GetSection("IdentityServer");
    var authority = configurationSection["Authority"];

    options.ProviderOptions.DefaultScopes.Add("cookbookapi");
});

var host = builder.Build();

await host.RunAsync();
