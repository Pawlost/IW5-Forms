using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;

public partial class FormListComponent
{
    [Inject]
    private FormFacade facade { get; set; } = null!;

    private ICollection<FormListModel> formList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        formList = await facade.GetAllFormsAsync();
        await base.OnInitializedAsync();
    }
}
