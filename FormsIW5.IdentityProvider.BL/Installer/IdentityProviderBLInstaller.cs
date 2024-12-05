using FormsIW5.Common.Installer;
using FormsIW5.IdentityProvider.BL.Facades.Interfaces;
using FormsIW5.IdentityProvider.BL.MapperProfiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.IdentityProvider.BL.Installer;

public class IdentityProviderBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        serviceCollection.AddAutoMapper(typeof(AppUserMapperProfile));

        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<IdentityProviderBLInstaller>()
                .AddClasses(classes => classes.AssignableTo<IIdentityFacade>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
    }
}
