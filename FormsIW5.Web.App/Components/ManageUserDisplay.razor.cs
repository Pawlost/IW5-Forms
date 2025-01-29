using FormsIW5.Web.BL.Facades;
using FormsIW5.Web.BL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FormsIW5.Web.App.Components;

public partial class ManageUserDisplay
{
    [Inject]
    private UtilsFacade UtilsFacade { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> authStateTask { get; set; } = null!;
    private bool IsAdmin { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        var authState = await authStateTask;
        string clientName = authState.User?.Identity?.IsAuthenticated is true ? ClientNames.LogInApiClientName : ClientNames.AnonymousClientName;

        IsAdmin = await UtilsFacade.IsAdmin(clientName);
        await base.OnParametersSetAsync();
    }
}
