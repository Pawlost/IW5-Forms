using FormsIW5.BL.Models.Common.User;
using FormsIW5.Web.BL.Facades.Interfaces;

namespace FormsIW5.Web.BL.Facades;

public class UserFacade : IWebFacade
{
    private readonly IUserApiClient apiClient;

    public UserFacade(IUserApiClient apiClient)
    {
        this.apiClient = apiClient;
    }
    public async Task<ICollection<UserListModel>> UserGetAsync()
    {
        return await apiClient.UserGetAsync();
    }

    public async Task<Guid> UserPostAsync(UserCreateModel newUser)
    {
        return await apiClient.UserPostAsync(newUser);
    }

    public async Task<Guid?> UserPutAsync(UserDetailModel user)
    {
        return await apiClient.UserPutAsync(user);
    }
    public async Task<UserListModel> ListAsync(Guid id)
    {
        return await apiClient.ListAsync(id);
    }
    public async Task<UserDetailModel> UserGetAsync(Guid id)
    {
        return await apiClient.UserGetAsync(id);
    }
    public async Task UserDeleteAsync(Guid id)
    {
        await apiClient.UserDeleteAsync(id);
    }
    public async Task<ICollection<UserListModel>> SearchAsync(string username)
    {
        return await apiClient.SearchAsync(username);
    }
}
