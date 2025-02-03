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


var apiBaseUrl = AddApiUrl(builder, ClientNames.LogInApiClientName, "ApiUrl:Base");
AddApiUrl(builder, ClientNames.UserApiClientName, "ApiUrl:User");

builder.Services.AddHttpClient(ClientNames.AnonymousClientName, client => client.BaseAddress = apiBaseUrl);

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<IHttpClientFactory>()!.CreateClient(ClientNames.LogInApiClientName));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration?.Bind("IdentityProvider", options.ProviderOptions);
    options.ProviderOptions.DefaultScopes.Add("offline_access");
    options.ProviderOptions.DefaultScopes.Add("iw5FormsScope");
});

var host = builder.Build();

await host.RunAsync();


static Uri? AddApiUrl(WebAssemblyHostBuilder builder, string clientName, string configurationPath) {
    Uri? clientUrl = builder.Configuration?.GetValue<Uri?>(configurationPath);

    if (clientUrl is not null)
    {
        builder.Services.AddHttpClient(clientName, client => client.BaseAddress = clientUrl)
        .AddHttpMessageHandler(serviceProvider
        => serviceProvider?.GetService<AuthorizationMessageHandler>()!
        .ConfigureHandler(
                authorizedUrls: [clientUrl.ToString()],
                scopes: ["iw5FormsScope", "offline_access"]));
    }

    return clientUrl;
}
