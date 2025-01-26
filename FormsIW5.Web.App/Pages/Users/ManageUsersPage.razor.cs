using FormsIW5.BL.Models.Common.User;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Users;

[Authorize(Policy="AdminPolicy")]
public partial class ManageUsersPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private UserFacade userFacade { get; set; } = null!;

    private ICollection<AppUserListModel> Users { get; set; } = [];

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    private string Username { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        Users = await userFacade.SearchUserAsync("");
        await base.OnInitializedAsync();
    }

    public void OnUserDelete(Guid userId) 
    {
        var user = Users.First(u => u.Id == userId);
        Users.Remove(user);
    }

    public async Task SearchUser() 
    {
        Users = await userFacade.SearchUserAsync(Username);
    }

    public void Back()
    {
        navigationManager.NavigateTo($"/forms/{Id}");
    }
}
