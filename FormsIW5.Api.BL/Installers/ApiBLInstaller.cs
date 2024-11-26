using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.Installer;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Api.BL.Installers;

public class ApiBLInstaller : IInstallers
{
    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ApiBLInstaller>()
            .AddClasses(classes => classes.AssignableTo<IAppFacadeBase>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
