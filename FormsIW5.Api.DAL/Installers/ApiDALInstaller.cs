using FormsIW5.Api.DAL.Entities.Interfaces;
using FormsIW5.Api.DAL.Repositories.Interfaces;
using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Api.DAL.Installers;

public class ApiDALInstaller : IDbInstaller
{
    public void Install(IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<FormsIW5DbContext>(options => options.UseSqlServer(connectionString));

        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ApiDALInstaller>()
            .AddClasses(classes => classes.AssignableTo(typeof(IApiRepository<>)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
