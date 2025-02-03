using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Common.Installer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Api.BL.Installer;

public class ApiBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        serviceCollection.AddAutoMapper(typeof(EntityBase), typeof(ApiBLInstaller));

        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ApiBLInstaller>()
            .AddClasses(classes => classes.AssignableTo<IAppFacadeBase>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
