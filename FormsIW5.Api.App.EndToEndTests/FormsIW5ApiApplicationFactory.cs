using System.Reflection;
using System.Text;
using FormsIW5.Api.DAL;
using FormsIW5.Api.DAL.Installer;
using FormsIW5.Common.Installer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
              collection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://localhost:5001";
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "https://localhost:5001",
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aVeryVeryVeryLongSecretKey1234567890")),
                };
            });

              collection.AddHttpContextAccessor();
          });

          var host = base.CreateHost(builder);

          using var deleteContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
          deleteContext.Database.EnsureDeleted();

          using var dbContext = host.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
          dbContext.Database.EnsureCreated();

          return host;
    }
}
