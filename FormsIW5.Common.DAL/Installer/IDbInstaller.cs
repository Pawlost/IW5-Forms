using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public interface IDbInstaller
{
    void Install(IServiceCollection serviceCollection, string connectionString, int timeoutSeconds);
}
