using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;

public partial class FormEditFormComponent
{
    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Parameter]
    public required Guid FormId { get; set; }

    private FormEditModel EditForm { get; set; } = new();
    private bool IsUpdated { get; set; }
    protected override async Task OnInitializedAsync()
    {
        EditForm = await FormFacade.GetEditAsync(FormId);
        await base.OnInitializedAsync();
    }

    public async Task SaveAsync()
    {
       var guid = await FormFacade.FormEditAsync(EditForm);
       IsUpdated = guid is not null;
    }
}
