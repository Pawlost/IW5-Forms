using FormsIW5.Web.App;
using FormsIW5.Web.BL.Installer;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FormsIW5.Common.Installer;
using FormsIW5.Web.BL.Facades;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("app");

builder.Services.Install<WebBLInstaller>(builder.Configuration);

builder.Services.AddTransient<AuthorizationMessageHandler>();

const string scope = "iw5FormsScope";

var apiBaseUrl = builder.Configuration.GetValue<Uri>("ApiBaseUrl");

builder.Services.AddHttpClient(FacadeBase.LogInClientName, client => client.BaseAddress = apiBaseUrl)
    .AddHttpMessageHandler(serviceProvider
    => serviceProvider?.GetService<AuthorizationMessageHandler>()!
    .ConfigureHandler(
            authorizedUrls: [apiBaseUrl.ToString()],
            scopes: [scope])
    );

builder.Services.AddHttpClient(FacadeBase.AnonymousClientName, client => client.BaseAddress = apiBaseUrl);

builder.Services.AddScoped<HttpClient>(serviceProvider => serviceProvider.GetService<IHttpClientFactory>()!.CreateClient(FacadeBase.LogInClientName));

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("IdentityProvider", options.ProviderOptions);
    options.ProviderOptions.DefaultScopes.Add(scope);
});

var host = builder.Build();

await host.RunAsync();
