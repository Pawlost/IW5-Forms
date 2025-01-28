using FormsIW5.Web.BL.Facades;
using FormsIW5.Web.BL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace FormsIW5.Web.App.Components;

public partial class LoginDisplay
{
    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> authStateTask { get; set; } = null!;

    private string UserName { get; set; } = "";

    protected override async Task OnParametersSetAsync()
    {
        var authState = await authStateTask;
        UserName = authState.User.FindFirst(x => x.Type == "username")?.Value ?? ""; 
        await base.OnParametersSetAsync();
    }

    private void BeginLogOut()
    {
        Navigation.NavigateToLogout("authentication/logout");
    }
}
