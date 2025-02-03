using AutoMapper;
using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using FormsIW5.BL.Models.Common.User;
using FormsIW5.IdentityProvider.DAL.Repositories.Interfaces;
using FormsIW5.IdentityProvider.BL.Common.Facades.Interfaces;
using FormsIW5.IdentityProvider.BL.Installer;

namespace FormsIW5.IdentityProvider.Api.BL.Facades;

public class AppUserFacade(
    IUserStore<AppUserEntity> userStore,
    IAppUserRepository appUserRepository,
     IPasswordHasher<AppUserEntity> passwordHasher,
    IMapper mapper) : IAppUserFacade, ILayerInstallable
{
    public async Task<Guid?> CreateAppUserAsync(AppUserCreateModel appUserModel, CancellationToken cancellationToken)
    {
        if (await userStore.FindByNameAsync(appUserModel.UserName, cancellationToken) is not null)
        {
            throw new ArgumentException($"User with username '{appUserModel.UserName}' already exists");
        }

        var appUserEntity = mapper.Map<AppUserEntity>(appUserModel);
        appUserEntity.PasswordHash = passwordHasher.HashPassword(appUserEntity, appUserModel.Password);
        await userStore.CreateAsync(appUserEntity, cancellationToken);
        return appUserEntity.Id;
    }

    public async Task<Guid> GetUserIdByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await userStore.FindByNameAsync(userName, cancellationToken);

        if (user is null)
        {
            throw new Exception("User not found");
        }

        return user.Id;
    }

    public async Task<AppUserDetailModel?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await userStore.FindByIdAsync(id.ToString(), cancellationToken);

        if (user is null)
        {
            return null;
        }

        return mapper.Map<AppUserDetailModel>(user);
    }

    public async Task<AppUserDetailModel?> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await userStore.FindByNameAsync(userName, cancellationToken);

        if (user is null)
        {
            return null;
        }

        return mapper.Map<AppUserDetailModel>(user);
    }

    public async Task<IList<AppUserListModel>> SearchAsync(string searchString)
    {
        var users = await appUserRepository.SearchAsync(searchString);
        return mapper.Map<List<AppUserListModel>>(users);
    }

    public async Task DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await userStore.FindByIdAsync(userId.ToString(), cancellationToken);
        if (user is not null)
        {
            await userStore.DeleteAsync(user, cancellationToken);
        }
    }
}
