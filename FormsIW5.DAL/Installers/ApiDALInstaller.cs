using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.DAL.Installers;

public static class ApiDALInstaller
{
    public static void InstallDAL(this IServiceCollection serviceCollection, string connectionString)
    {
        serviceCollection.AddDbContext<FormsIW5DbContext>(options => options.UseSqlServer(connectionString));

        serviceCollection.Scan(selector =>
            selector.FromCallingAssembly()
            .AddClasses()
            .AsMatchingInterface()
            .WithScopedLifetime());
    }
}
