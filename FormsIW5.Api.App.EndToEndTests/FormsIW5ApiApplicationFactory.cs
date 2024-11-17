using System.Reflection;
using FormsIW5.Api.DAL.Installers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Common.Installer;
using FormsIW5.Api.DAL;

namespace FormsIW5.Api.App.EndToEndTests;

public class FormsIW5ApiApplicationFactory : WebApplicationFactory<Program>
{
    private IHost host { get; set; }
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("QA");

        builder.ConfigureAppConfiguration(config =>
        {
            config.AddJsonFile("appsettings.QA.json", optional: false, reloadOnChange: true).AddUserSecrets<Program>();
        }).ConfigureServices((context, collection) =>
        {
            var connectionString = context.Configuration.GetConnectionString("EndToEndTestConnection");

            var controllerAssemblyName = typeof(Program).Assembly.FullName;
            collection.AddMvc().AddApplicationPart(Assembly.Load(controllerAssemblyName));

            collection.Install<ApiDALInstaller>(connectionString!, 30);
        });

        host = base.CreateHost(builder);
       
        return host;
    }

    public async Task MigrateAsync()
    {
        using var dbContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public override async ValueTask DisposeAsync() {
        using var deleteContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
        await deleteContext.Database.EnsureDeletedAsync();
        await base.DisposeAsync();
    }
}
