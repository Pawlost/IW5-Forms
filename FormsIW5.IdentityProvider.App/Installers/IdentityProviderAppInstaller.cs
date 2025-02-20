﻿using FormsIW5.Common.Installer;
using FormsIW5.IdentityProvider.DAL;
using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FormsIW5.IdentityProvider.App.Installers;

public class IdentityProviderAppInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        serviceCollection.AddIdentity<AppUserEntity, AppRoleEntity>()
            .AddEntityFrameworkStores<IdentityProviderDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<AppUserEntity>>(TokenOptions.DefaultProvider);

        serviceCollection.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;

            options.SignIn.RequireConfirmedEmail = false;
        });
    }
}
