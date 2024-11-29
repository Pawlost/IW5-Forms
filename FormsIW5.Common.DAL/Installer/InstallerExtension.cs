using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public static class InstallerExtension
{
    public static void Install<TInstaller>(this IServiceCollection serviceCollection)
        where TInstaller : IInstallers, new()
    {
        new TInstaller().Install(serviceCollection);
    }
    public static void Install<TInstaller>(this IServiceCollection serviceCollection, string connectionString, int timeoutSeconds = 3)
        where TInstaller : IDbInstaller, new()
    {
        new TInstaller().Install(serviceCollection, connectionString, timeoutSeconds);
    }

    public static void Install<TInstaller>(this IServiceCollection serviceCollection, Uri? uri)
        where TInstaller : IClientInstaller, new()
    {
        new TInstaller().Install(serviceCollection, uri);
    }
}
