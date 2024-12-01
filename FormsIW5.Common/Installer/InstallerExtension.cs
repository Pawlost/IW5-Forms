using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public static class InstallerExtension
{
    public static void Install<TInstaller>(this IServiceCollection serviceCollection, IConfiguration configuration)
        where TInstaller : IInstaller, new()
    {
        new TInstaller().Install(serviceCollection, configuration);
    }
}
