using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public static class InstallerExtension
{
    public static void Install<TInstaller>(this IServiceCollection serviceCollection)
        where TInstaller : IInstaller, new()
    {
        new TInstaller().Install(serviceCollection);
    }
    public static void Install<TInstaller>(this IServiceCollection serviceCollection, string connectionString)
    where TInstaller : IDbInstaller, new()
    {
        new TInstaller().Install(serviceCollection, connectionString);
    }
}
