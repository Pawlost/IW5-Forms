using FormsIW5.Common.Installer;
using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.IdentityProvider.DAL;

public class IdentityProviderDALInstaller : IInstaller
{
    private const string ConnectionStringName = "DefaultConnection";
    private const int Timeout = 12;

    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string not found.");
        }

        serviceCollection.AddDbContext<IdentityProviderDbContext>(options => options.UseSqlServer(connectionString, options => options.CommandTimeout(Timeout)));


        serviceCollection.AddScoped<IUserStore<AppUserEntity>, UserStore<AppUserEntity, AppRoleEntity, IdentityProviderDbContext, Guid, AppUserClaimEntity, AppUserRoleEntity, AppUserLoginEntity, AppUserTokenEntity, AppRoleClaimEntity>>();
        serviceCollection.AddScoped<IRoleStore<AppRoleEntity>, RoleStore<AppRoleEntity, IdentityProviderDbContext, Guid, AppUserRoleEntity, AppRoleClaimEntity>>();

        //serviceCollection.AddTransient<IAppUserRepository, AppUserRepository>();
    }
}
