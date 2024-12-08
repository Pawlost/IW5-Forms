using FormsIW5.Web.App;
using FormsIW5.Web.BL.Installer;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FormsIW5.Common.Installer;
using FormsIW5.Web.BL.Facades;
using FormsIW5.Web.BL;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services.Install<WebBLInstaller>(builder.Configuration);

builder.Services.AddTransient<AuthorizationMessageHandler>();

const string scope = "iw5FormsScope";

var apiBaseUrl = builder.Configuration.GetValue<Uri>("ApiBaseUrl");

builder.Services.AddHttpClient(ClientNames.LogInClientName, client => client.BaseAddress = apiBaseUrl)
    .AddHttpMessageHandler(serviceProvider
    => serviceProvider?.GetService<AuthorizationMessageHandler>()!
    .ConfigureHandler(
            authorizedUrls: [apiBaseUrl.ToString()],
            scopes: [scope])
    );

builder.Services.AddHttpClient(ClientNames.AnonymousClientName, client => client.BaseAddress = apiBaseUrl);

builder.Services.AddScoped(serviceProvider => serviceProvider.GetService<IHttpClientFactory>()!.CreateClient(ClientNames.LogInClientName));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("IdentityProvider", options.ProviderOptions);
    options.ProviderOptions.DefaultScopes.Add(scope);
});

var host = builder.Build();

await host.RunAsync();
