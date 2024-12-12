using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;

public partial class FormEditFormComponent
{
    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Parameter]
    public FormEditModel FormEditModel { get; set; } = new();

    public async Task SaveAsync()
    {
        await FormFacade.FormEditAsync(Data);
    }
}
