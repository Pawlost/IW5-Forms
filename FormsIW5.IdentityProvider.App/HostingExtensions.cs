using FormsIW5.IdentityProvider.App.Installers;
using FormsIW5.IdentityProvider.App.Services;
using FormsIW5.IdentityProvider.BL.Installer;
using FormsIW5.Common.Installer;
using Serilog;
using FormsIW5.IdentityProvider.DAL.Installer;
using FormsIW5.IdentityProvider.DAL;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.IdentityProvider.App
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.Install<IdentityProviderDALInstaller>(builder.Configuration);
            builder.Services.Install<IdentityProviderBLInstaller>(builder.Configuration);
            builder.Services.Install<IdentityProviderAppInstaller>(builder.Configuration);
            var allowedRedirectUri = builder.Configuration.GetValue<string>("IdentityProvider:RedirectUri");

            if (allowedRedirectUri is not null)
            {
                Config.Clients.First().RedirectUris.Add(allowedRedirectUri);
            }
            else {
                throw new NullReferenceException("Redirect uri must be set for client");
            }

            var logoutUri = builder.Configuration.GetValue<string>("IdentityProvider:PostLogoutRedirectUri");
            if (logoutUri is not null)
            {
                Config.Clients.First().PostLogoutRedirectUris.Add(logoutUri);
            }

            builder.Services.AddRazorPages();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApiDocument();

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
            MigrateDB(app.Services);

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

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();

            app.MapRazorPages().RequireAuthorization();

            return app;
        }

        public static void MigrateDB(IServiceProvider services)
        {
           using var dbContext = services.CreateScope().ServiceProvider.GetRequiredService<IdentityProviderDbContext>();
           dbContext.Database.Migrate();
        }
    }
}
