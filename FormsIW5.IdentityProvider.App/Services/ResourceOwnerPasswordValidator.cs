﻿using Duende.IdentityServer.Validation;
using FormsIW5.IdentityProvider.BL.Facades.Interfaces;
using IdentityModel;

namespace FormsIW5.IdentityProvider.App.Services;

public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly IAppUserManagerFacade appUserFacade;

    public ResourceOwnerPasswordValidator(IAppUserManagerFacade appUserFacade)
    {
        this.appUserFacade = appUserFacade;
    }

    public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        var areCredentialsValid = await appUserFacade.ValidateCredentialsAsync(context.UserName, context.Password);

        if (areCredentialsValid)
        {
            var userId = await appUserFacade.GetUserIdByUserNameAsync(context.UserName);

            context.Result = new GrantValidationResult(userId.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
