using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Common.Installer;

public interface IInstaller
{
    void Install(IServiceCollection serviceCollection);
}
