using FormsIW5.Web.BL.Facades;
using FormsIW5.Web.BL;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using FormsIW5.Web.App.Options;

namespace FormsIW5.Web.App.Components;

public partial class ManageUserDisplay
{
    [Inject]
    private UtilsFacade UtilsFacade { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> authStateTask { get; set; } = null!;
    private bool IsAdmin { get; set; }

    private string UsersManageUrl { get; set; } = ""; 

    [Inject]
    private IOptions<ClientUrlOptions> options { get; set; } = null!;

    protected override async Task OnParametersSetAsync()
    {
        var authState = await authStateTask;
        string clientName = authState.User?.Identity?.IsAuthenticated is true ? ClientNames.LogInApiClientName : ClientNames.AnonymousClientName;

        IsAdmin = await UtilsFacade.IsAdmin(clientName);
        UsersManageUrl = options.Value.UserManager ?? "";
        await base.OnParametersSetAsync();
    }
}
