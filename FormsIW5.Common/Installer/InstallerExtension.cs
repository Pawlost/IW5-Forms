using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public static class InstallerExtension
{
    public static IServiceCollection Install<TInstaller>(this IServiceCollection serviceCollection, IConfiguration? configuration = null)
        where TInstaller : IInstaller, new()
    {
        new TInstaller().Install(serviceCollection, configuration);
        return serviceCollection;
    }
}
