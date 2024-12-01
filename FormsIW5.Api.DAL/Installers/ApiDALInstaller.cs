using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Api.DAL.Installers;

public class ApiDALInstaller : IInstaller
{
    private const string ConnectionStringName = "DefaultConnection";
    private const int Timeout = 12;
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string not found.");
        }

        serviceCollection.AddDbContext<FormsIW5DbContext>(options => options.UseSqlServer(connectionString, options => options.CommandTimeout(Timeout)));

        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ApiDALInstaller>()
            .AddClasses(classes => classes.AssignableTo(typeof(IApiRepository<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
