using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public interface IInstallers
{
    void Install(IServiceCollection serviceCollection);
}
public interface IDbInstaller
{
    void Install(IServiceCollection serviceCollection, string connectionString, int timeoutSeconds);
}

public interface IClientInstaller
{
    void Install(IServiceCollection serviceCollection, Uri? uri);
}
