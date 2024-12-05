using System.Reflection;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Common.Installer;
using FormsIW5.Api.DAL;
using FormsIW5.Api.DAL.Installer;

namespace FormsIW5.Api.App.EndToEndTests;

public class FormsIW5ApiApplicationFactory : WebApplicationFactory<Program>
{
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

              collection.Install<ApiDALInstaller>(context.Configuration);
          });

          var host = base.CreateHost(builder);

          using var deleteContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
          deleteContext.Database.EnsureDeleted();

          using var dbContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
          dbContext.Database.EnsureCreated();

          return host;
    }
}
