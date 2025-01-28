using FormsIW5.Web.App;
using FormsIW5.Web.BL.Installer;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FormsIW5.Common.Installer;
using FormsIW5.Web.BL;
using FormsIW5.BL.Models.Common.Installers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services.Install<WebBLInstaller>(builder.Configuration);
builder.Services.Install<ValidatorInstaller>(builder.Configuration);

builder.Services.AddTransient<AuthorizationMessageHandler>();

var apiBaseUrl = builder.Configuration.GetValue<Uri>("ApiBaseUrl");

builder.Services.AddHttpClient(ClientNames.LogInApiClientName, client => client.BaseAddress = apiBaseUrl)
    .AddHttpMessageHandler(serviceProvider
    => serviceProvider?.GetService<AuthorizationMessageHandler>()!
    .ConfigureHandler(
            authorizedUrls: [apiBaseUrl.ToString()],
            scopes: ["iw5FormsScope", "offline_access"])
    );

builder.Services.AddHttpClient(ClientNames.AnonymousClientName, client => client.BaseAddress = apiBaseUrl);

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<IHttpClientFactory>()!.CreateClient(ClientNames.LogInApiClientName));

Uri? identityUrl = builder.Configuration?.GetValue<Uri?>("IdentityProvider:Authority");

if (identityUrl is not null)
{
    builder.Services.AddHttpClient(ClientNames.UserApiClientName, client => client.BaseAddress = identityUrl)
    .AddHttpMessageHandler(serviceProvider
    => serviceProvider?.GetService<AuthorizationMessageHandler>()!
    .ConfigureHandler(
            authorizedUrls: [identityUrl.ToString()],
            scopes: ["iw5FormsScope", "offline_access"]));
}

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration?.Bind("IdentityProvider", options.ProviderOptions);
    options.ProviderOptions.DefaultScopes.Add("offline_access");
    options.ProviderOptions.DefaultScopes.Add("iw5FormsScope");
});

var host = builder.Build();

await host.RunAsync();
