using FormsIW5.BL.Models.Common.User;
using FormsIW5.IdentityProvider.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.IdentityProvider.App.Components.Users;

public partial class UserComponent
{
    [Parameter]
    public required AppUserListModel User { get; set; }

    [Inject]
    private AppUserFacade userFacade { get; set; } = null!;

    [Parameter]
    public required EventCallback<Guid> OnDelete { get; set; }

    public async Task DeleteQuestionOptionAsync()
    {
        await userFacade.DeleteUserAsync(User.Id);
        await OnDelete.InvokeAsync(User.Id);
    }
}
