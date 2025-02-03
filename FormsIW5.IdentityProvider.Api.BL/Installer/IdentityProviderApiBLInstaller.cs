using FormsIW5.Common.Installer;
using FormsIW5.IdentityProvider.BL.MapperProfiles;
using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.IdentityProvider.BL.Installer;

public class IdentityProviderApiBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        serviceCollection.AddAutoMapper(typeof(AppUserMapperProfile));
        serviceCollection.AddScoped<IPasswordHasher<AppUserEntity>, PasswordHasher<AppUserEntity>>();
        serviceCollection.AddScoped<IPasswordHasher<AppUserEntity>, PasswordHasher<AppUserEntity>>();
        
        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<IdentityProviderApiBLInstaller>()
                .AddClasses(classes => classes.AssignableTo<ILayerInstallable>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
    }
}
