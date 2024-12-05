using FormsIW5.IdentityProvider.App.Installers;
using FormsIW5.IdentityProvider.App.Services;
using FormsIW5.IdentityProvider.BL.Installers;
using FormsIW5.Common.Installer;
using Serilog;
using FormsIW5.IdentityProvider.DAL.Installers;

namespace FormsIW5.IdentityProvider.App
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.Install<IdentityProviderDALInstaller>(builder.Configuration);
            builder.Services.Install<IdentityProviderBLInstaller>(builder.Configuration);
            builder.Services.Install<IdentityProviderAppInstaller>(builder.Configuration);

            builder.Services.AddRazorPages();

            builder.Services.AddIdentityServer(options =>
                {
                    // https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/api_scopes#authorization-based-on-scopes
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiResources(Config.ApiResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddResourceOwnerValidator<ResourceOwnerPasswordValidator>()
                .AddProfileService<LocalAppUserProfileService>();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();

            app.UseAuthorization();
            app.MapRazorPages().RequireAuthorization();
           // app.UseUserEndpoints();

            return app;
        }
    }
}
