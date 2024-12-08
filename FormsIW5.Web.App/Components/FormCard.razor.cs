using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components;

public partial class FormCard
{
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Parameter]
    public required FormListModel Form { get; set; }

    public void Redirect()
    {
        navigationManager.NavigateTo($"/forms/{Form.Id}");
    }
}
