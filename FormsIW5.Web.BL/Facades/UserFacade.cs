using FormsIW5.BL.Models.Common.User;

namespace FormsIW5.Web.BL.Facades;

public class UserFacade : FacadeBase<IUserApiClient>
{
    public UserFacade(IHttpClientFactory clientFactory, IUserApiClient client) : base(clientFactory, client)
    {
    }

    public async Task<ICollection<AppUserListModel>> SearchUserAsync(string userName)
    {
        SwitchClient(ClientNames.UserApiClientName);
        return await client.SearchAsync(userName);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        SwitchClient(ClientNames.UserApiClientName);
        await client.DeleteAsync(id);
    }
}
